using System;
using System.Linq;
using System.Runtime.Serialization;

namespace Draft.Responses
{
    [DataContract]
    internal class EtcdError : IEtcdError
    {

#pragma warning disable 0649
        // Warning disabled due to this value being populated via json deserialization

        [DataMember(Name = "errorCode")]
        private EtcdErrorCode? _errorCode;

#pragma warning restore 0649

        [DataMember(Name = "cause")]
        public string Cause { get; private set; }

        [IgnoreDataMember]
        public EtcdErrorCode ErrorCode
        {
            get { return _errorCode ?? EtcdErrorCode.Unknown; }
        }

        [DataMember(Name = "index")]
        public long? Index { get; private set; }

        [DataMember(Name = "message")]
        public string Message { get; private set; }

    }
}
