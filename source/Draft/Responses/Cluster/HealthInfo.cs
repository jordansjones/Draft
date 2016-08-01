using System;
using System.Linq;
using System.Runtime.Serialization;

namespace Draft.Responses.Cluster
{
    [DataContract]
    internal class HealthInfo : IHealthInfo
    {
        [DataMember(Name = "health")]
        public bool Value { get; private set; } 

    }
}