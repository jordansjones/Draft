using System;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Draft.Exceptions
{
    /// <summary>
    ///     Represents an error when attempting to use an etcd reserved keyword as a key in a key based operation.
    /// </summary>
    [Serializable]
    public class KeyIsPreservedException : EtcdException
    {

        /// <summary>
        ///     Initializes a new <see cref="KeyIsPreservedException" /> instance.
        /// </summary>
        public KeyIsPreservedException() {}

        /// <summary>
        ///     Initializes a new <see cref="KeyIsPreservedException" /> instance with a specified error message.
        /// </summary>
        public KeyIsPreservedException(string message) : base(message) {}
        
        /// <summary>
        ///     Initializes a new <see cref="KeyIsPreservedException" /> instance for use in BCL deserialization
        /// </summary>
        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        protected KeyIsPreservedException(SerializationInfo info, StreamingContext context) : base(info, context) {}

        /// <summary>
        ///     Indicates that this exception is due to attempting to use an etcd reserved keyword as a key operation key.
        /// </summary>
        public override bool IsKeyIsPreserved
        {
            get { return true; }
        }

    }
}
