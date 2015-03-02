using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Draft.Responses.Cluster
{
    [DataContract]
    internal class ClusterMember : IClusterMember
    {

        [DataMember(Name = "clientURLs")]
        public List<Uri> ClientUrls { get; private set; }

        [DataMember(Name = "peerURLs")]
        public List<Uri> PeerUrls { get; private set; }

        [IgnoreDataMember]
        Uri[] IClusterMember.ClientUrls
        {
            get { return ClientUrls.ToArray(); }
        }

        [DataMember(Name = "id")]
        public string Id { get; private set; }

        [DataMember(Name = "name")]
        public string Name { get; private set; }

        [IgnoreDataMember]
        Uri[] IClusterMember.PeerUrls
        {
            get { return PeerUrls.ToArray(); }
        }

    }
}
