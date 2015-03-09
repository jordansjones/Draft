using System;
using System.Linq;
using System.Runtime.Serialization;

namespace Draft.Responses.Cluster
{
    [DataContract]
    internal class ClusterMember : IClusterMember
    {

        [field : IgnoreDataMember]
        private Uri[] _clientUrls;

        [field : IgnoreDataMember]
        private Uri[] _peerUrls;

        [DataMember(Name = "clientURLs")]
        public Uri[] ClientUrls
        {
            get { return _clientUrls ?? (_clientUrls = new Uri[0]); }
            private set { _clientUrls = value; }
        }

        [DataMember(Name = "id")]
        public string Id { get; private set; }

        [DataMember(Name = "name")]
        public string Name { get; private set; }

        [DataMember(Name = "peerURLs")]
        public Uri[] PeerUrls
        {
            get { return _peerUrls ?? (_peerUrls = new Uri[0]); }
            private set { _peerUrls = value; }
        }

    }
}
