using System.Runtime.Serialization;

namespace Draft.Models
{
    [DataContract]
    public class Health
    {
        [DataMember(Name = "health")]
        public bool Value { get; private set; } 

    }
}