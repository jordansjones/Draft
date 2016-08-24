using System;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Draft.Exceptions
{
    /// <summary>
    ///     Represents an error where an invalid form was posted for the etcd operation.
    /// </summary>
    [Serializable]
    public class InvalidFormException : EtcdException
    {

        /// <summary>
        ///     Initializes a new <see cref="InvalidFormException" /> instance.
        /// </summary>
        public InvalidFormException() {}

        /// <summary>
        ///     Initializes a new <see cref="InvalidFormException" /> instance with a specified error message.
        /// </summary>
        public InvalidFormException(string message) : base(message) {}
        
        /// <summary>
        ///     Initializes a new <see cref="InvalidFormException" /> instance for use in BCL deserialization
        /// </summary>
        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        protected InvalidFormException(SerializationInfo info, StreamingContext context) : base(info, context) {}

        /// <summary>
        ///     Indicates that this exception is due to an invalid form post.
        /// </summary>
        public override bool IsInvalidForm
        {
            get { return true; }
        }

    }
}
