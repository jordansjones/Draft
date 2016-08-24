using System;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Draft.Exceptions
{
    /// <summary>
    ///     Represents an error where the operation requires as previous value, but was missing in the form post.
    /// </summary>
    [Serializable]
    public class PreviousValueRequiredException : EtcdException
    {

        /// <summary>
        ///     Initializes a new <see cref="PreviousValueRequiredException" /> instance.
        /// </summary>
        public PreviousValueRequiredException() {}

        /// <summary>
        ///     Initializes a new <see cref="PreviousValueRequiredException" /> instance with a specified error message.
        /// </summary>
        public PreviousValueRequiredException(string message) : base(message) {}
        
        /// <summary>
        ///     Initializes a new <see cref="PreviousValueRequiredException" /> instance for use in BCL deserialization
        /// </summary>
        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        protected PreviousValueRequiredException(SerializationInfo info, StreamingContext context) : base(info, context) {}

        /// <summary>
        ///     Indicates that this exception is due to the previous value field missing in the form post.
        /// </summary>
        public override bool IsPreviousValueRequired
        {
            get { return true; }
        }

    }
}
