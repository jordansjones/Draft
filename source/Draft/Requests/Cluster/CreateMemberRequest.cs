﻿using System;
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

        public string Name { get; private set; }

        public List<Uri> Uris { get; private set; }

        public async Task<IClusterMember> Execute()
        {
            var values = new ListDictionary
            {
                {
                    // Key
                    Constants.Etcd.Parameter_Name,
                    Name
                },
                {
                    // Key
                    Constants.Etcd.Parameter_PeerURLs,
                    Uris.ToArray()
                }
            };

            try
            {
                return await TargetUrl
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

        public ICreateMemberRequest WithName(string name)
        {
            Name = name;
            return this;
        }

        public ICreateMemberRequest WithPeerUri(params Uri[] uris)
        {
            Uris.AddRange(uris);
            return this;
        }

    }
}