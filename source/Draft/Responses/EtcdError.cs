using System;
using System.Linq;
using System.Runtime.Serialization;

namespace Draft.Responses
{
    [DataContract]
    internal class EtcdError : IEtcdError
    {

        [DataMember(Name = "errorCode")]
        private EtcdErrorCode? _errorCode;

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
