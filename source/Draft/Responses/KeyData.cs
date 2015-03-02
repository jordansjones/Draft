using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Draft.Responses
{
    [DataContract]
    internal class KeyData : IKeyData
    {

        [DataMember(Name = "nodes")]
        public List<KeyData> Children { get; private set; }

        [IgnoreDataMember]
        IReadOnlyCollection<IKeyData> IKeyData.Children
        {
            get { return Children; }
        }

        [DataMember(Name = "createdIndex")]
        public long CreatedIndex { get; private set; }

        [DataMember(Name = "expiration")]
        public DateTime? Expiration { get; private set; }

        [DataMember(Name = "dir")]
        public bool IsDir { get; private set; }

        [DataMember(Name = "key")]
        public string Key { get; private set; }

        [DataMember(Name = "modifiedIndex")]
        public long? ModifiedIndex { get; private set; }

        [DataMember(Name = "ttl")]
        public long? TtlSeconds { get; private set; }

        [DataMember(Name = "value")]
        public string Value { get; private set; }

    }
}
