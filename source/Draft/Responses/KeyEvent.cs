using System;
using System.Linq;
using System.Runtime.Serialization;

namespace Draft.Responses
{
    [DataContract]
    internal class KeyEvent : IKeyEvent, IHaveResponseHeaders, IHaveAValueConverter
    {

        [field : IgnoreDataMember]
        private readonly ResponseHeaders _headers = new ResponseHeaders();

        [field : IgnoreDataMember]
        private Func<IKeyDataValueConverter> _valueConverter;

        [DataMember(Name = "node")]
        public KeyData Data { get; private set; }

        [DataMember(Name = "prevNode")]
        public KeyData PreviousData { get; private set; }

        public IResponseHeaders GetResponseHeaders()
        {
            return Headers;
        }

        [IgnoreDataMember]
        public Func<IKeyDataValueConverter> ValueConverter
        {
            get { return _valueConverter; }
            set
            {
                _valueConverter = value;

                if (Data != null)
                {
                    Data.ValueConverter = _valueConverter;
                }

                if (PreviousData != null)
                {
                    PreviousData.ValueConverter = _valueConverter;
                }
            }
        }

        [property : IgnoreDataMember]
        public ResponseHeaders Headers
        {
            get { return _headers; }
            set { _headers.DeepCopy(value); }
        }

        [DataMember(Name = "action")]
        public KeyEventType Action { get; private set; }

        [IgnoreDataMember]
        IKeyData IKeyEvent.Data
        {
            get { return Data; }
        }

        [IgnoreDataMember]
        IKeyData IKeyEvent.PreviousData
        {
            get { return PreviousData; }
        }

    }
}
