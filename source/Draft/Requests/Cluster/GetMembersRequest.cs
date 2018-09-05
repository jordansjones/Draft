using System;

using Flurl.Http;

using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

using Draft.Endpoints;
using Draft.Responses.Cluster;

namespace Draft.Requests.Cluster
{
    internal class GetMembersRequest : BaseRequest, IGetMembersRequest
    {

        public GetMembersRequest(IEtcdClient etcdClient, EndpointPool endpointPool, params string[] pathParts)
            : base(etcdClient, endpointPool, pathParts) {}

        public async Task<IClusterMember[]> Execute()
        {
            try
            {
                var collection = await TargetUrl
                    .GetAsync()
                    .ReceiveJson<ClusterMemberCollection>();

                return collection.Members;
            }
            catch (FlurlHttpException e)
            {
                throw await e.ProcessException();
            }
        }

        public TaskAwaiter<IClusterMember[]> GetAwaiter()
        {
            return Execute().GetAwaiter();
        }

    }
}
