using System;
using System.Linq;
using System.Runtime.Serialization;

namespace Draft.Responses
{
    [DataContract]
    internal class EtcdVersion : IEtcdVersion
    {

        [DataMember(Name = "releaseVersion")]
        public string Internal { get; private set; }

        [DataMember(Name = "internalVersion")]
        public string Release { get; private set; }

    }
}
