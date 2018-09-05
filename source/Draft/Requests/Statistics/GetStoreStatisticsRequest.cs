using System;

using Flurl.Http;

using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

using Draft.Endpoints;
using Draft.Responses.Statistics;

namespace Draft.Requests.Statistics
{
    internal class GetStoreStatisticsRequest : BaseRequest, IGetStoreStatisticsRequest
    {

        public GetStoreStatisticsRequest(IEtcdClient etcdClient, EndpointPool endpointPool, params string[] pathParts) : base(etcdClient, endpointPool, pathParts) {}

        public async Task<IStoreStatistics> Execute()
        {
            try
            {
                return await TargetUrl
                    .GetAsync()
                    .ReceiveJson<StoreStatistics>();
            }
            catch (FlurlHttpException e)
            {
                throw await e.ProcessException();
            }
        }

        public TaskAwaiter<IStoreStatistics> GetAwaiter()
        {
            return Execute().GetAwaiter();
        }

    }
}
