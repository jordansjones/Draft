using System;

using Flurl.Http;

using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

using Draft.Endpoints;
using Draft.Responses.Statistics;

namespace Draft.Requests.Statistics
{
    internal class GetLeaderStatisticsRequest : BaseRequest, IGetLeaderStatisticsRequest
    {

        public GetLeaderStatisticsRequest(IEtcdClient etcdClient, EndpointPool endpointPool, params string[] pathParts) : base(etcdClient, endpointPool, pathParts) {}

        public async Task<ILeaderStatistics> Execute()
        {
            try
            {
                return await TargetUrl
                    .GetAsync()
                    .ReceiveJson<LeaderStatistics>();
            }
            catch (FlurlHttpException e)
            {
                throw e.ProcessException();
            }
        }

        public TaskAwaiter<ILeaderStatistics> GetAwaiter()
        {
            return Execute().GetAwaiter();
        }

    }
}
