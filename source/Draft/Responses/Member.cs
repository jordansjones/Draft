using System;
using System.Linq;
using System.Runtime.Serialization;

namespace Draft.Responses
{
    [DataContract]
    internal class Member
    {

        [DataMember(Name = "id")]
        public string Id { get; private set; }
        
        [DataMember(Name = "name")]
        public string Name { get; private set; }
        
        [DataMember(Name = "peerURLs")]
        public Uri[] PeerUrls { get; private set; }
        
        [DataMember(Name = "clientURLs")]
        public Uri[] ClientUrls { get; private set; }

    }
}
