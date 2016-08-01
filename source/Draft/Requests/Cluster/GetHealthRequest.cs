using System;

using Flurl.Http;

using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

using Draft.Endpoints;
using Draft.Responses.Cluster;

namespace Draft.Requests.Cluster
{
    internal class GetHealthRequest : BaseRequest, IGetHealthRequest
    {

        public GetHealthRequest(IEtcdClient etcdClient, EndpointPool endpointPool, params string[] pathParts)
            : base(etcdClient, endpointPool, pathParts) {}

        public async Task<IHealthInfo> Execute()
        {
            try
            {
                return await TargetUrl
                    .GetAsync()
                    .ReceiveJson<HealthInfo>();
            }
            catch (FlurlHttpException e)
            {
                throw e.ProcessException();
            }
        }

        public TaskAwaiter<IHealthInfo> GetAwaiter()
        {
            return Execute().GetAwaiter();
        }

    }
}
