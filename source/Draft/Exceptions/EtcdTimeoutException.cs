using System;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Draft.Exceptions
{
    /// <summary>
    /// Represents an error due to an HTTP request/response timeout.
    /// </summary>
    [Serializable]
    public class EtcdTimeoutException : EtcdException
    {

        /// <summary>
        ///     Initializes a new <see cref="EtcdTimeoutException" /> instance.
        /// </summary>
        public EtcdTimeoutException() {}

        /// <summary>
        ///     Initializes a new <see cref="EtcdTimeoutException" /> instance with a specified error message.
        /// </summary>
        public EtcdTimeoutException(string message) : base(message) {}

        /// <summary>
        ///     Initializes a new <see cref="DirectoryNotEmptyException" /> instance for use in BCL deserialization
        /// </summary>
        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        protected EtcdTimeoutException(SerializationInfo info, StreamingContext context) : base(info, context) {}

        /// <summary>
        ///     Indicates that this exception is due to an HTTP timeout error.
        /// </summary>
        public override bool IsTimeout
        {
            get { return true; }
        }


    }
}
