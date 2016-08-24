using System;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Draft.Exceptions
{
    /// <summary>
    ///     Represents an error where the etcd operation requires an index or value parameter, but neither was provided.
    /// </summary>
    [Serializable]
    public class IndexOrValueRequiredException : EtcdException
    {

        /// <summary>
        ///     Initializes a new <see cref="IndexOrValueRequiredException" /> instance.
        /// </summary>
        public IndexOrValueRequiredException() {}

        /// <summary>
        ///     Initializes a new <see cref="IndexOrValueRequiredException" /> instance with a specified error message.
        /// </summary>
        public IndexOrValueRequiredException(string message) : base(message) {}
        
        /// <summary>
        ///     Initializes a new <see cref="IndexOrValueRequiredException" /> instance for use in BCL deserialization
        /// </summary>
        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        protected IndexOrValueRequiredException(SerializationInfo info, StreamingContext context) : base(info, context) {}

        /// <summary>
        ///     Indicates that this exception is due to the request missing the index or value property.
        /// </summary>
        public override bool IsIndexOrValueRequired
        {
            get { return true; }
        }

    }
}
