using System;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Draft.Responses.Cluster
{
    [DataContract]
    internal class ClusterMember : IClusterMember
    {

        [DataMember(Name = "clientURLs")]
        public Uri[] ClientUrls { get; private set; }

        [DataMember(Name = "id")]
        public string Id { get; private set; }

        [DataMember(Name = "name")]
        public string Name { get; private set; }

        [DataMember(Name = "peerURLs")]
        public Uri[] PeerUrls { get; private set; }

        public override string ToString()
        {
            var cu = ClientUrls.LastOrDefault();
            var pu = PeerUrls.LastOrDefault();

            var sb = new StringBuilder();
            sb.AppendFormat("Id: {0}, Name: {1}", Id, Name);
            if (cu != null)
            {
                sb.AppendFormat(", ClientUrl: {0}", cu.ToString());
            }
            if (pu != null)
            {
                sb.AppendFormat(", PeerUrl: {0}", pu.ToString());
            }
            return sb.ToString();
        }

    }
}
