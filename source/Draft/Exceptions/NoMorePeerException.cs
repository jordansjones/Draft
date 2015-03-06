using System;
using System.Linq;

namespace Draft.Exceptions
{
    /// <summary>
    ///     Represents a reaching the max number of peers in a cluster error.
    /// </summary>
    public class NoMorePeerException : EtcdException
    {

        /// <summary>
        ///     Initializes a new <see cref="NoMorePeerException" /> instance.
        /// </summary>
        public NoMorePeerException() {}

        /// <summary>
        ///     Initializes a new <see cref="NoMorePeerException" /> instance with a specified error message.
        /// </summary>
        public NoMorePeerException(string message) : base(message) {}

        /// <summary>
        ///     Indicates that this exception is due to reaching the max number of peers in the cluster.
        /// </summary>
        public override bool IsNoMorePeer
        {
            get { return true; }
        }

    }
}
