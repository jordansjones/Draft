using System;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Draft.Exceptions
{
    /// <summary>
    ///     Represents a general problem with the requst to etcd.
    /// </summary>
    [Serializable]
    public class BadRequestException : EtcdException
    {

        /// <summary>
        ///     Initializes a new <see cref="BadRequestException" /> instance.
        /// </summary>
        public BadRequestException() {}

        /// <summary>
        ///     Initializes a new <see cref="BadRequestException" /> instance with a specified error message.
        /// </summary>
        public BadRequestException(string message) : base(message) {}
        
        /// <summary>
        ///     Initializes a new <see cref="BadRequestException" /> instance for use in BCL deserialization
        /// </summary>
        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        protected BadRequestException(SerializationInfo info, StreamingContext context) : base(info, context) {}

        /// <summary>
        ///     Indicates that this exception is due to a general problem with the request to etcd.
        /// </summary>
        public override bool IsBadRequest
        {
            get { return true; }
        }

    }
}
