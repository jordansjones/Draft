using System;
using System.Linq;

namespace Draft.Exceptions
{
    /// <summary>
    ///     Represents an internal raft error.
    /// </summary>
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
        ///     Indicates that this exception is due to an internal raft error.
        /// </summary>
        public override bool IsRaftInternal
        {
            get { return true; }
        }

    }
}
