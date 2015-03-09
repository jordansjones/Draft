using System;
using System.Linq;
using System.Runtime.Serialization;

namespace Draft.Responses
{
    [DataContract]
    internal class KeyData : IKeyData, IHaveAValueConverter
    {

        private KeyData[] _children;

        [field : IgnoreDataMember]
        private Func<IKeyDataValueConverter> _valueConverter;

        [DataMember(Name = "nodes")]
        public KeyData[] Children
        {
            get { return _children ?? (_children = new KeyData[0]); }
            private set { _children = value; }
        }

        [IgnoreDataMember]
        public Func<IKeyDataValueConverter> ValueConverter
        {
            get { return _valueConverter; }
            set
            {
                _valueConverter = value;

                foreach (var c in Children)
                {
                    c.ValueConverter = _valueConverter;
                }
            }
        }

        [IgnoreDataMember]
        IKeyData[] IKeyData.Children
        {
            // ReSharper disable once CoVariantArrayConversion
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

        [DataMember(Name = "value")]
        public string RawValue { get; private set; }

        [DataMember(Name = "ttl")]
        public long? TtlSeconds { get; private set; }

    }
}
