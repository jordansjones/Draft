using System;

using Flurl.Http;

using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

using Draft.Responses.Cluster;

using Flurl;

namespace Draft.Requests.Cluster
{
    internal class GetLeaderRequest : BaseRequest, IGetLeaderRequest
    {

        public GetLeaderRequest(IEtcdClient client, Url endpointUrl, string containerPath) : base(client, endpointUrl, containerPath) {}

        public async Task<IClusterMember> Execute()
        {
            return await TargetUrl
                .GetAsync()
                .ReceiveJson<ClusterMember>();
        }

        public TaskAwaiter<IClusterMember> GetAwaiter()
        {
            return Execute().GetAwaiter();
        }

    }
}
