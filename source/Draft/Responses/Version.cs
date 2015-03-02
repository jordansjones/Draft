using System;
using System.Linq;
using System.Runtime.Serialization;

namespace Draft.Responses
{
    [DataContract]
    internal class Version
    {

        [DataMember(Name = "releaseVersion")]
        public string ReleaseVersion { get; private set; }

        [DataMember(Name = "internalVersion")]
        public string InternalVersion { get; private set; }

    }
}