using System;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Draft.Exceptions
{
    /// <summary>
    ///     Represents an error when attempting to modify the root keyspace.
    /// </summary>
    [Serializable]
    public class RootIsReadOnlyException : EtcdException
    {

        /// <summary>
        ///     Initializes a new <see cref="RootIsReadOnlyException" /> instance.
        /// </summary>
        public RootIsReadOnlyException() {}

        /// <summary>
        ///     Initializes a new <see cref="RootIsReadOnlyException" /> instance with a specified error message.
        /// </summary>
        public RootIsReadOnlyException(string message) : base(message) {}
        
        /// <summary>
        ///     Initializes a new <see cref="RootIsReadOnlyException" /> instance for use in BCL deserialization
        /// </summary>
        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        protected RootIsReadOnlyException(SerializationInfo info, StreamingContext context) : base(info, context) {}

        /// <summary>
        ///     Indicates that this exception is due to the root keyspace being read only.
        /// </summary>
        /// <remarks>You probably tried to set a value on the root keyspace.</remarks>
        public override bool IsRootReadOnly
        {
            get { return true; }
        }

    }
}
