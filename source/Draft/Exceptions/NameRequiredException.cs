using System;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Draft.Exceptions
{
    /// <summary>
    ///     Represents an error where the etcd operation requires a name field, but one was not provided.
    /// </summary>
    [Serializable]
    public class NameRequiredException : EtcdException
    {

        /// <summary>
        ///     Initializes a new <see cref="NameRequiredException" /> instance.
        /// </summary>
        public NameRequiredException() {}

        /// <summary>
        ///     Initializes a new <see cref="NameRequiredException" /> instance with a specified error message.
        /// </summary>
        public NameRequiredException(string message) : base(message) {}
        
        /// <summary>
        ///     Initializes a new <see cref="NameRequiredException" /> instance for use in BCL deserialization
        /// </summary>
        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        protected NameRequiredException(SerializationInfo info, StreamingContext context) : base(info, context) {}

        /// <summary>
        ///     Indicates that this exception is due to the name field is missing in the form post.
        /// </summary>
        public override bool IsNameRequired
        {
            get { return true; }
        }

    }
}
