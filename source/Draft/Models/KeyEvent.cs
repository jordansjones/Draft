using System.Runtime.Serialization;

namespace Draft.Models
{
    [DataContract]
    internal class KeyEvent
    {

        [DataMember(Name = "action")]
        public KeyEventType Action { get; private set; }
        
        [DataMember(Name = "node")]
        public KeyData Data { get; private set; }
        
        [DataMember(Name = "prevNode")]
        public KeyData PreviousData { get; private set; }

    }
}