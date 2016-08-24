using System;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Draft.Exceptions
{
    /// <summary>
    ///     Represents an error where the etcd operation requires a value or ttl field, but neither was provided.
    /// </summary>
    [Serializable]
    public class ValueOrTtlRequiredException : EtcdException
    {

        /// <summary>
        ///     Initializes a new <see cref="ValueOrTtlRequiredException" /> instance.
        /// </summary>
        public ValueOrTtlRequiredException() {}

        /// <summary>
        ///     Initializes a new <see cref="ValueOrTtlRequiredException" /> instance with a specified error message.
        /// </summary>
        public ValueOrTtlRequiredException(string message) : base(message) {}
        
        /// <summary>
        ///     Initializes a new <see cref="ValueOrTtlRequiredException" /> instance for use in BCL deserialization
        /// </summary>
        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        protected ValueOrTtlRequiredException(SerializationInfo info, StreamingContext context) : base(info, context) {}

        /// <summary>
        ///     Indicates that this exception is due to the value or ttl field missing in the form post.
        /// </summary>
        public override bool IsValueOrTtlRequired
        {
            get { return true; }
        }

    }
}
