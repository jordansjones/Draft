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
    internal class UpdateMemberPeerUrlsRequest : BaseRequest, IUpdateMemberPeerUrlsRequest
    {

        public UpdateMemberPeerUrlsRequest(IEtcdClient client, Url endpointUrl, string containerPath) : base(client, endpointUrl, containerPath)
        {
            Uris = new List<Uri>();
        }

        public string MemberId { get; private set; }

        public List<Uri> Uris { get; private set; }

        public async Task<IClusterMember> Execute()
        {
            var values = new ListDictionary
            {
                {
                    // Key
                    Constants.Etcd.Parameter_PeerURLs,
                    Uris.ToArray()
                }
            };

            try
            {
                return await TargetUrl
                    .AppendPathSegment(MemberId)
                    .PostJsonAsync(values)
                    .ReceiveJson<ClusterMember>();
            }
            catch (FlurlHttpException e)
            {
                throw e.ProcessException();
            }
        }

        public TaskAwaiter<IClusterMember> GetAwaiter()
        {
            return Execute().GetAwaiter();
        }

        public IUpdateMemberPeerUrlsRequest WithMemberId(string memberId)
        {
            MemberId = memberId;
            return this;
        }

        public IUpdateMemberPeerUrlsRequest WithPeerUri(params Uri[] uris)
        {
            Uris.AddRange(uris);
            return this;
        }

    }
}
