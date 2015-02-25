using System;
using System.Reactive.Linq;

using Flurl.Http;

using System.Linq;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Threading;
using System.Threading.Tasks;

using Flurl;

namespace Draft.Requests
{
    internal class WatchRequest : ObservableBase<object>, IWatchRequest
    {

        private readonly Url _endpointUrl;

        public WatchRequest(Url endpointUrl, string path, bool single)
        {
            _endpointUrl = endpointUrl;
            Path = path;
            Single = single;
        }

        public Url EndpointUrl
        {
            get { return new Url(_endpointUrl); }
        }

        public int? ModifiedIndex { get; private set; }

        public string Path { get; private set; }

        public bool? Recursive { get; private set; }

        public bool Single { get; private set; }

        public IWatchRequest WithModifiedIndex(int? index = null)
        {
            ModifiedIndex = index;
            return this;
        }

        public IWatchRequest WithRecursive(bool isRecursive = true)
        {
            Recursive = isRecursive;
            return this;
        }

        private async Task StartPollingAsync(IObserver<object> observer, CancellationToken cancellationToken, bool isSingle, bool? recursive, int? modifiedIndex)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    var response = await (EndpointUrl
                        .AppendPathSegment(Path)
                        .SetQueryParam(EtcdConstants.Parameter_Wait, EtcdConstants.Parameter_True)
                        .Conditionally(recursive.HasValue && recursive.Value, x => x.SetQueryParam(EtcdConstants.Parameter_Recursive, EtcdConstants.Parameter_True))
                        // ReSharper disable once PossibleInvalidOperationException
                        .Conditionally(modifiedIndex.HasValue, x => x.SetQueryParam(EtcdConstants.Parameter_WaitIndex, modifiedIndex.Value))
                        .GetAsync(cancellationToken))
                        .ConfigureAwait(true);

                    if (cancellationToken.IsCancellationRequested) break;

                    var result = await (Task.FromResult(response).ReceiveString()).ConfigureAwait(true);

                    // TODO: Some stuff with the response
                    // In order to get the response's modified index
                    // value to pass through on the next request

                    observer.OnNext(result);
                    if (isSingle) break;
                }
                catch (FlurlHttpTimeoutException)
                {
                    /* Restart the connection */
                }
                catch (FlurlHttpException e)
                {
                    observer.OnError(e);
                    break;
                }
                catch (Exception e)
                {
                    observer.OnError(e);
                    break;
                }
            }

            observer.OnCompleted();
        }

        protected override IDisposable SubscribeCore(IObserver<object> observer)
        {   
            var recursive = Recursive;
            var modifiedIndex = ModifiedIndex;
            var isSingle = Single;
            return Observable.Create<object>((o, c) => StartPollingAsync(o, c, isSingle, recursive, modifiedIndex))
                .SubscribeOn(CurrentThreadScheduler.Instance)
                .Subscribe(observer.OnNext, observer.OnError, observer.OnCompleted);
        }

    }
}
