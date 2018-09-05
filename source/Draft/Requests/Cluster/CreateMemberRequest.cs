using System;
using System.Collections.Generic;

using Flurl.Http;

using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

using Draft.Endpoints;
using Draft.Responses.Cluster;

namespace Draft.Requests.Cluster
{
    internal class CreateMemberRequest : BaseRequest, ICreateMemberRequest
    {

        public CreateMemberRequest(IEtcdClient etcdClient, EndpointPool endpointPool, params string[] pathParts) 
            : base(etcdClient, endpointPool, pathParts)
        {
            Uris = new List<Uri>();
        }

        public string Name { get; private set; }

        public List<Uri> Uris { get; private set; }

        public async Task<IClusterMember> Execute()
        {
            var values = new FormBodyBuilder()
                .Add(Constants.Etcd.Parameter_Name, Name)
                .Add(Constants.Etcd.Parameter_PeerURLs, Uris.Select(x => x.GetComponents(UriComponents.SchemeAndServer, UriFormat.Unescaped)).ToArray())
                .Build();

            try
            {
                return await TargetUrl
                    .PostJsonAsync(values)
                    .ReceiveJson<ClusterMember>();
            }
            catch (FlurlHttpException e)
            {
                throw await e.ProcessException();
            }
        }

        public TaskAwaiter<IClusterMember> GetAwaiter()
        {
            return Execute().GetAwaiter();
        }

        public ICreateMemberRequest WithName(string name)
        {
            Name = name;
            return this;
        }

        public ICreateMemberRequest WithPeerUri(params Uri[] uris)
        {
            if (uris != null && uris.Any())
            {
                Uris.AddRange(uris);
            }
            return this;
        }

    }
}
