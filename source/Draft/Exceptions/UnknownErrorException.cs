using System;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Draft.Exceptions
{
    /// <summary>
    ///     Represents an unknown error.
    /// </summary>
    [Serializable]
    public class UnknownErrorException : EtcdException
    {

        /// <summary>
        ///     Initializes a new <see cref="UnknownErrorException" /> instance.
        /// </summary>
        public UnknownErrorException() {}

        /// <summary>
        ///     Initializes a new <see cref="UnknownErrorException" /> instance with a specified error message.
        /// </summary>
        public UnknownErrorException(string message) : base(message) {}
        
        /// <summary>
        ///     Initializes a new <see cref="UnknownErrorException" /> instance for use in BCL deserialization
        /// </summary>
        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        protected UnknownErrorException(SerializationInfo info, StreamingContext context) : base(info, context) {}

        /// <summary>
        ///     Indicates that this exception is due to an unknown error.
        /// </summary>
        public override bool IsUnknown
        {
            get { return true; }
        }

    }
}
