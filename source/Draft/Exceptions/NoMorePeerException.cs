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

        public override bool IsNoMorePeer
        {
            get { return true; }
        }

    }
}
