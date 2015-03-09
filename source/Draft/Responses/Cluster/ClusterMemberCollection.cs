using System;
using System.Linq;
using System.Runtime.Serialization;

namespace Draft.Responses.Cluster
{
    [DataContract]
    internal class ClusterMemberCollection
    {

        [field : IgnoreDataMember]
        private ClusterMember[] _members;

        [DataMember(Name = "members")]
        public ClusterMember[] Members
        {
            get { return _members ?? (_members = new ClusterMember[0]); }
            private set { _members = value; }
        }

    }
}
