using System;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Draft.Exceptions
{
    /// <summary>
    ///     Represents an error in the etcd request.
    /// </summary>
    [Serializable]
    public class InvalidRequestException : EtcdException
    {

        /// <summary>
        ///     Initializes a new <see cref="InvalidRequestException" /> instance.
        /// </summary>
        public InvalidRequestException() {}

        /// <summary>
        ///     Initializes a new <see cref="InvalidRequestException" /> instance with a specified error message.
        /// </summary>
        public InvalidRequestException(string message) : base(message) {}
        
        /// <summary>
        ///     Initializes a new <see cref="InvalidRequestException" /> instance for use in BCL deserialization
        /// </summary>
        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        protected InvalidRequestException(SerializationInfo info, StreamingContext context) : base(info, context) {}

        /// <summary>
        ///     Indicates that this exception is due to an invalid request error.
        /// </summary>
        public override bool IsInvalidRequest
        {
            get { return true; }
        }

    }
}
