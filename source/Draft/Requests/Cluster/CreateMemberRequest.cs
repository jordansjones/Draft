using System;
using System.Collections.Generic;

using Flurl.Http;

using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

using Draft.Responses.Cluster;

using Flurl;

namespace Draft.Requests.Cluster
{
    internal class CreateMemberRequest : BaseRequest, ICreateMemberRequest
    {

        public CreateMemberRequest(IEtcdClient client, Url endpointUrl, string containerPath) : base(client, endpointUrl, containerPath)
        {
            Uris = new List<Uri>();
        }

        public List<Uri> Uris { get; private set; }

        public async Task<IClusterMember> Execute()
        {
            var values = new ListDictionary
            {
                {
                    // Key
                    EtcdConstants.Parameter_PeerURLs,
                    Uris.ToArray()
                }
            };

            return await TargetUrl
                .PostJsonAsync(values)
                .ReceiveJson<ClusterMember>();
        }

        public TaskAwaiter<IClusterMember> GetAwaiter()
        {
            return Execute().GetAwaiter();
        }

        public ICreateMemberRequest WithPeerUri(params Uri[] uris)
        {
            Uris.AddRange(uris);
            return this;
        }

    }
}
