using System;
using System.Linq;
using System.Runtime.Serialization;

namespace Draft.Responses.Cluster
{
    [DataContract]
    internal class ClusterMemberCollection
    {
        
        [DataMember(Name = "members")]
        public ClusterMember[] Members { get; private set; }

    }
}
