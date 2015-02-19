using System.Runtime.Serialization;

namespace Draft.Models
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