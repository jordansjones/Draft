using System;
using System.Reactive.Linq;

using Flurl.Http;

using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Threading;
using System.Threading.Tasks;

using Draft.Responses;

using Flurl;

namespace Draft.Requests
{
    internal class WatchRequest : ObservableBase<IKeyEvent>, IWatchRequest
    {

        private readonly Url _endpointUrl;

        private readonly IEtcdClient _etcdClient;

        public WatchRequest(IEtcdClient etcdClient, Url endpointUrl, string path, bool single)
        {
            _etcdClient = etcdClient;
            _endpointUrl = endpointUrl;
            Path = path;
            Single = single;
        }

        public Url EndpointUrl
        {
            get { return new Url(_endpointUrl); }
        }

        public long? ModifiedIndex { get; private set; }

        public string Path { get; private set; }

        public bool? Recursive { get; private set; }

        public bool Single { get; private set; }

        public IEtcdClient EtcdClient
        {
            get { return _etcdClient; }
        }

        public IWatchRequest WithModifiedIndex(long? index = null)
        {
            ModifiedIndex = index;
            return this;
        }

        public IWatchRequest WithRecursive(bool isRecursive = true)
        {
            Recursive = isRecursive;
            return this;
        }

        private Task<HttpResponseMessage> CallEndpoint(bool? recursive, long? index)
        {
            return EndpointUrl
                .AppendPathSegment(Path)
                .SetQueryParam(Constants.Etcd.Parameter_Wait, Constants.Etcd.Parameter_True)
                .Conditionally(recursive.HasValue && recursive.Value, x => x.SetQueryParam(Constants.Etcd.Parameter_Recursive, Constants.Etcd.Parameter_True))
                // ReSharper disable once PossibleInvalidOperationException
                .Conditionally(index.HasValue, x => x.SetQueryParam(Constants.Etcd.Parameter_WaitIndex, index.Value))
                .GetAsync();
        }

        private async Task StartPollingAsync(IObserver<IKeyEvent> observer, CancellationToken cancellationToken, bool isSingle, bool? recursive, long? modifiedIndex)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    var response = await CallEndpoint(recursive, modifiedIndex);

                    if (cancellationToken.IsCancellationRequested) { break; }

                    var result = await Task.FromResult(response).ReceiveEtcdResponse<KeyEvent>(EtcdClient);

                    observer.OnNext(result);
                    if (isSingle) { break; }

                    modifiedIndex = TryUpdateIndex(response);
                }
                catch (FlurlHttpTimeoutException)
                {
                    /* Restart the connection */
                }
                catch (FlurlHttpException e)
                {
                    var idx = TryUpdateIndex(e);
                    if (idx.HasValue)
                    {
                        modifiedIndex = idx;
                        continue;
                    }
                    observer.OnError(e.ProcessException());
                    break;
                }
                catch (Exception e)
                {
                    observer.OnError(e.ProcessException());
                    break;
                }
            }

            observer.OnCompleted();
        }

        protected override IDisposable SubscribeCore(IObserver<IKeyEvent> observer)
        {
            var recursive = Recursive;
            var modifiedIndex = ModifiedIndex;
            var isSingle = Single;
            return Observable.Create<IKeyEvent>((o, c) => StartPollingAsync(o, c, isSingle, recursive, modifiedIndex))
                .SubscribeOn(CurrentThreadScheduler.Instance)
                .Subscribe(observer.OnNext, observer.OnError, observer.OnCompleted);
        }

        private static long? TryUpdateIndex(FlurlHttpException e)
        {
            if (e == null) { return null; }
            if (e.Call == null) { return null; }
            if (e.Call.HttpStatus != HttpStatusCode.BadRequest) { return null; }
            if (e.Call.Response == null) { return null; }

            return TryUpdateIndex(e.Call.Response);
        }

        private static long? TryUpdateIndex(HttpResponseMessage response)
        {
            return response == null
                ? null
                : response.TryGetHeaderAsLong(Constants.Etcd.Header_EtcdIndex);
        }

    }
}
