using System;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Draft.Exceptions
{
    /// <summary>
    ///     Represents an internal client error.
    /// </summary>
    [Serializable]
    public class ClientInternalException : EtcdException
    {

        /// <summary>
        ///     Initializes a new <see cref="ClientInternalException" /> instance.
        /// </summary>
        public ClientInternalException() {}

        /// <summary>
        ///     Initializes a new <see cref="ClientInternalException" /> instance with a specified error message.
        /// </summary>
        public ClientInternalException(string message) : base(message) {}
        
        /// <summary>
        ///     Initializes a new <see cref="ClientInternalException" /> instance for use in BCL deserialization
        /// </summary>
        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        protected ClientInternalException(SerializationInfo info, StreamingContext context) : base(info, context) {}

        /// <summary>
        ///     Indicates that this exception is due to an internal client error
        /// </summary>
        public override bool IsClientInternal
        {
            get { return true; }
        }

    }
}
