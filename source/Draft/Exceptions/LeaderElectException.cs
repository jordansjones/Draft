using System;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Draft.Exceptions
{
    /// <summary>
    ///     Represents an error where the called operation failed due to etcd being in the middle of a leader election.
    /// </summary>
    [Serializable]
    public class LeaderElectException : EtcdException
    {

        /// <summary>
        ///     Initializes a new <see cref="LeaderElectException" /> instance.
        /// </summary>
        public LeaderElectException() {}

        /// <summary>
        ///     Initializes a new <see cref="LeaderElectException" /> instance with a specified error message.
        /// </summary>
        public LeaderElectException(string message) : base(message) {}
        
        /// <summary>
        ///     Initializes a new <see cref="LeaderElectException" /> instance for use in BCL deserialization
        /// </summary>
        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        protected LeaderElectException(SerializationInfo info, StreamingContext context) : base(info, context) {}

        /// <summary>
        ///     Indicates that this exception is due to an in process leader election.
        /// </summary>
        public override bool IsLeaderElect
        {
            get { return true; }
        }

    }
}
