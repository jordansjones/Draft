using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

using Draft.Responses.Cluster;

using Flurl;
using Flurl.Http;

namespace Draft.Requests.Cluster
{
    internal class GetMembersRequest : BaseRequest, IGetMembersRequest
    {

        public GetMembersRequest(IEtcdClient client, Url endpointUrl, string containerPath) : base(client, endpointUrl, containerPath) {}

        public async Task<IClusterMember[]> Execute()
        {
            var collection = await TargetUrl
                .GetAsync()
                .ReceiveJson<ClusterMemberCollection>();

            return collection.Members;
        }

        public TaskAwaiter<IClusterMember[]> GetAwaiter()
        {
            return Execute().GetAwaiter();
        }

    }
}
