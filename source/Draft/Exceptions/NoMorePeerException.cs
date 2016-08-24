using System;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Draft.Exceptions
{
    /// <summary>
    ///     Represents a reaching the max number of peers in a cluster error.
    /// </summary>
    [Serializable]
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
        ///     Initializes a new <see cref="NoMorePeerException" /> instance for use in BCL deserialization
        /// </summary>
        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        protected NoMorePeerException(SerializationInfo info, StreamingContext context) : base(info, context) {}

        /// <summary>
        ///     Indicates that this exception is due to reaching the max number of peers in the cluster.
        /// </summary>
        public override bool IsNoMorePeer
        {
            get { return true; }
        }

    }
}
