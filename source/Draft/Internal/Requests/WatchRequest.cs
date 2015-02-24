using System;
using System.Reactive.Linq;

using Flurl.Http;

using System.Linq;
using System.Reactive;
using System.Threading;
using System.Threading.Tasks;

using Flurl;

namespace Draft.Requests
{
    public class WatchRequest : ObservableBase<object>, IWatchRequest
    {

        public WatchRequest(Url endpointUrl, string path, bool single = false)
        {
            EndpointUrl = endpointUrl;
            Path = path;
            Single = single;
        }

        public Url EndpointUrl { get; private set; }

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

        private async Task<object> Execute(CancellationToken cancellationToken)
        {
            return await EndpointUrl.ToString()
                .AppendPathSegment(Path)
                .Conditionally(Recursive.HasValue, x => x.SetQueryParam(EtcdConstants.Parameter_Recursive, Recursive.Value))
                .Conditionally(ModifiedIndex.HasValue, x => x.SetQueryParam(EtcdConstants.Parameter_WaitIndex, ModifiedIndex.Value))
                .GetJsonAsync();
        }

        private IObservable<object> StartAsyncRequest()
        {
            return Observable.Create<object>(
                async (obs, ct) =>
                {
                    while (!ct.IsCancellationRequested)
                    {
                        try
                        {
                            var result = await Execute(ct);
                            obs.OnNext(result);
                        }
                        catch (FlurlHttpTimeoutException) {}
                        catch (FlurlHttpException e)
                        {
                            obs.OnError(e);
                            break;
                        }
                    }
                    
                    obs.OnCompleted();
                });
        }

        protected override IDisposable SubscribeCore(IObserver<object> observer)
        {
            var obs = StartAsyncRequest();
            if (Single)
            {
                obs = obs.Take(1);
            }

            return obs.Subscribe(x => observer.OnNext(x), x => observer.OnError(x), () => observer.OnCompleted());
        }

    }
}
