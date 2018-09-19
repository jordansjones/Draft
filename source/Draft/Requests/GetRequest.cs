using System;

using Flurl.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

using Draft.Endpoints;
using Draft.Responses;

namespace Draft.Requests
{
    internal class GetRequest : BaseRequest, IGetRequest
    {

        public GetRequest(IEtcdClient etcdClient, EndpointPool endpointPool, params string[] pathParts)
            : base(etcdClient, endpointPool, pathParts) {}

        public bool? Quorum { get; private set; }

        public bool? Recursive { get; private set; }

        public async Task<IKeyEvent> Execute()
        {
            try
            {
                var url = TargetUrl
                    .Conditionally(Quorum.HasValue && Quorum.Value,
                        x => x.SetQueryParam(Constants.Etcd.Parameter_Quorum, Constants.Etcd.Parameter_True))
                    .Conditionally(Recursive.HasValue && Recursive.Value,
                        x => x.SetQueryParam(Constants.Etcd.Parameter_Recursive, Constants.Etcd.Parameter_True));

                var requestTask = HttpGetTimeout == null
                    ? url.WithTimeout(HttpGetTimeout.GetValueOrDefault()).GetAsync()
                    : url.GetAsync();

                return await requestTask
                    .ReceiveEtcdResponse<KeyEvent>(EtcdClient);

            }
            catch (FlurlHttpException e)
            {
                throw await e.ProcessException();
            }
        }

        public TaskAwaiter<IKeyEvent> GetAwaiter()
        {
            return Execute().GetAwaiter();
        }

        public IGetRequest WithQuorum(bool quorum = true)
        {
            Quorum = quorum;
            return this;
        }

        public IGetRequest WithRecursive(bool recursive = true)
        {
            Recursive = recursive;
            return this;
        }

        public IGetRequest WithTimeout(TimeSpan timeout)
        {
            _httpTimeout = timeout;
            return this;
        }

        private TimeSpan? _httpTimeout;
        protected TimeSpan? HttpGetTimeout => _httpTimeout ?? EndpointPoolHttpTimeout;
    }
}
