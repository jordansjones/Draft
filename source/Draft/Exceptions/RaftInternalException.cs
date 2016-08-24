using System;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Draft.Exceptions
{
    /// <summary>
    ///     Represents an internal raft error.
    /// </summary>
    [Serializable]
    public class RaftInternalException : EtcdException
    {

        /// <summary>
        ///     Initializes a new <see cref="RaftInternalException" /> instance.
        /// </summary>
        public RaftInternalException() {}

        /// <summary>
        ///     Initializes a new <see cref="RaftInternalException" /> instance with a specified error message.
        /// </summary>
        public RaftInternalException(string message) : base(message) {}
        
        /// <summary>
        ///     Initializes a new <see cref="RaftInternalException" /> instance for use in BCL deserialization
        /// </summary>
        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        protected RaftInternalException(SerializationInfo info, StreamingContext context) : base(info, context) {}

        /// <summary>
        ///     Indicates that this exception is due to an internal raft error.
        /// </summary>
        public override bool IsRaftInternal
        {
            get { return true; }
        }

    }
}
