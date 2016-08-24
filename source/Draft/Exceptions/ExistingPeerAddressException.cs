using System;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Draft.Exceptions
{
    /// <summary>
    ///     Represents an error where the operation's passed peer address value matched an existing peer address in etcd.
    /// </summary>
    [Serializable]
    public class ExistingPeerAddressException : EtcdException
    {

        /// <summary>
        ///     Initializes a new <see cref="ExistingPeerAddressException" /> instance.
        /// </summary>
        public ExistingPeerAddressException() {}

        /// <summary>
        ///     Initializes a new <see cref="ExistingPeerAddressException" /> instance with a specified error message.
        /// </summary>
        public ExistingPeerAddressException(string message) : base(message) {}
        
        /// <summary>
        ///     Initializes a new <see cref="ExistingPeerAddressException" /> instance for use in BCL deserialization
        /// </summary>
        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        protected ExistingPeerAddressException(SerializationInfo info, StreamingContext context) : base(info, context) {}

        /// <summary>
        ///     Indicates that this exception is due to there being an existing peer address that matches the value passed.
        /// </summary>
        public override bool IsExistingPeerAddress
        {
            get { return true; }
        }

    }
}
