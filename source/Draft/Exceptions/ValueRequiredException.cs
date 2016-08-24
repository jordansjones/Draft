using System;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Draft.Exceptions
{
    /// <summary>
    ///     Represents an error where the value field was missing in the operation's form post.
    /// </summary>
    [Serializable]
    public class ValueRequiredException : EtcdException
    {

        /// <summary>
        ///     Initializes a new <see cref="ValueRequiredException" /> instance.
        /// </summary>
        public ValueRequiredException() {}

        /// <summary>
        ///     Initializes a new <see cref="ValueRequiredException" /> instance with a specified error message.
        /// </summary>
        public ValueRequiredException(string message) : base(message) {}
        
        /// <summary>
        ///     Initializes a new <see cref="ValueRequiredException" /> instance for use in BCL deserialization
        /// </summary>
        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        protected ValueRequiredException(SerializationInfo info, StreamingContext context) : base(info, context) {}

        /// <summary>
        ///     Indicates that this exception is due to the value field missing in the form post.
        /// </summary>
        public override bool IsValueRequired
        {
            get { return true; }
        }

    }
}
