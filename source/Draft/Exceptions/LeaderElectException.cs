using System;
using System.Linq;

namespace Draft.Exceptions
{
    /// <summary>
    ///     Represents an error where the called operation failed due to etcd being in the middle of a leader election.
    /// </summary>
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
        ///     Indicates that this exception is due to an in process leader election.
        /// </summary>
        public override bool IsLeaderElect
        {
            get { return true; }
        }

    }
}
