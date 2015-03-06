using System;
using System.Linq;

namespace Draft.Exceptions
{
    /// <summary>
    ///     Represents an error where the operation's passed peer address value matched an existing peer address in etcd.
    /// </summary>
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
        ///     Indicates that this exception is due to there being an existing peer address that matches the value passed.
        /// </summary>
        public override bool IsExistingPeerAddress
        {
            get { return true; }
        }

    }
}
