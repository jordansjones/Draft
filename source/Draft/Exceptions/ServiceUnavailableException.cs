using System;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Draft.Exceptions
{
    /// <summary>
    ///     Represents a "Service unavailable error".
    /// </summary>
    [Serializable]
    public class ServiceUnavailableException : EtcdException
    {

        /// <summary>
        ///     Initializes a new <see cref="ServiceUnavailableException" /> instance.
        /// </summary>
        public ServiceUnavailableException() {}

        /// <summary>
        ///     Initializes a new <see cref="ServiceUnavailableException" /> instance with a specified error message.
        /// </summary>
        public ServiceUnavailableException(string message) : base(message) {}
        
        /// <summary>
        ///     Initializes a new <see cref="ServiceUnavailableException" /> instance for use in BCL deserialization
        /// </summary>
        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        protected ServiceUnavailableException(SerializationInfo info, StreamingContext context) : base(info, context) {}

        /// <summary>
        ///     Indicates that this exception is due to a general problem with the request to etcd.
        /// </summary>
        public override bool IsServiceUnavailable
        {
            get { return true; }
        }

    }
}
