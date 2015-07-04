using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

using Draft.Endpoints;
using Draft.Responses.Statistics;

using Flurl.Http;

namespace Draft.Requests.Statistics
{
    internal class GetSelfStatisticsRequest : BaseRequest, IGetServerStatisticsRequest
    {

        public GetSelfStatisticsRequest(IEtcdClient etcdClient, EndpointPool endpointPool, params string[] pathParts) : base(etcdClient, endpointPool, pathParts) {}

        public async Task<IServerStatistics> Execute()
        {
            try
            {
                return await TargetUrl
                    .GetAsync()
                    .ReceiveJson<ServerStatistics>();
            }
            catch (FlurlHttpException e)
            {
                throw e.ProcessException();
            }
        }

        public TaskAwaiter<IServerStatistics> GetAwaiter()
        {
            return Execute().GetAwaiter();
        }

    }
}
