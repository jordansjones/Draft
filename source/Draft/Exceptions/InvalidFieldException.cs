using System;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Draft.Exceptions
{
    /// <summary>
    ///     Represents an error where the operation was passed an invalid field value.
    /// </summary>
    [Serializable]
    public class InvalidFieldException : EtcdException
    {

        /// <summary>
        ///     Initializes a new <see cref="InvalidFieldException" /> instance.
        /// </summary>
        public InvalidFieldException() {}

        /// <summary>
        ///     Initializes a new <see cref="InvalidFieldException" /> instance with a specified error message.
        /// </summary>
        public InvalidFieldException(string message) : base(message) {}
        
        /// <summary>
        ///     Initializes a new <see cref="InvalidFieldException" /> instance for use in BCL deserialization
        /// </summary>
        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        protected InvalidFieldException(SerializationInfo info, StreamingContext context) : base(info, context) {}

        /// <summary>
        ///     Indicates that this exception is due to an invalid field value.
        /// </summary>
        public override bool IsInvalidField
        {
            get { return true; }
        }

    }
}
