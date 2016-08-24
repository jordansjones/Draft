using System;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Draft.Exceptions
{
    /// <summary>
    ///     Represents an error when attempting to connect to a non-etcd endpoint.
    /// </summary>
    [Serializable]
    public class InvalidHostException : EtcdException
    {

        /// <summary>
        ///     Initializes a new <see cref="InvalidHostException" /> instance.
        /// </summary>
        public InvalidHostException() {}

        /// <summary>
        ///     Initializes a new <see cref="InvalidHostException" /> instance with a specified error message.
        /// </summary>
        public InvalidHostException(string message) : base(message) {}
        
        /// <summary>
        ///     Initializes a new <see cref="InvalidHostException" /> instance for use in BCL deserialization
        /// </summary>
        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        protected InvalidHostException(SerializationInfo info, StreamingContext context) : base(info, context) {}

        /// <summary>
        ///     Indicates that this exception is due to attempting to connect to a non-etcd endpoint.
        /// </summary>
        public override bool IsInvalidHost
        {
            get { return true; }
        }

    }
}
