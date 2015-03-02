using System;
using System.Linq;
using System.Runtime.Serialization;

namespace Draft.Responses
{
    [DataContract]
    internal class Health
    {
        [DataMember(Name = "health")]
        public bool Value { get; private set; } 

    }
}