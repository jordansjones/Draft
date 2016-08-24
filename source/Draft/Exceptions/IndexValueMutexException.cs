using System;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Draft.Exceptions
{
    /// <summary>
    ///     Represents an error where the etcd operation requires an index or value parameter, but both was provided.
    /// </summary>
    [Serializable]
    public class IndexValueMutexException : EtcdException
    {

        /// <summary>
        ///     Initializes a new <see cref="IndexValueMutexException" /> instance.
        /// </summary>
        public IndexValueMutexException() {}

        /// <summary>
        ///     Initializes a new <see cref="IndexValueMutexException" /> instance with a specified error message.
        /// </summary>
        public IndexValueMutexException(string message) : base(message) {}
        
        /// <summary>
        ///     Initializes a new <see cref="IndexValueMutexException" /> instance for use in BCL deserialization
        /// </summary>
        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        protected IndexValueMutexException(SerializationInfo info, StreamingContext context) : base(info, context) {}

        /// <summary>
        ///     Indicates that this exception is due to "Index and value cannot both be specified."
        /// </summary>
        public override bool IsIndexValueMutex
        {
            get { return true; }
        }

    }
}
