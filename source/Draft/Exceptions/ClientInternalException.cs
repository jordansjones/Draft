using System;
using System.Linq;

namespace Draft.Exceptions
{
    /// <summary>
    ///     Represents an internal client error.
    /// </summary>
    public class ClientInternalException : EtcdException
    {

        /// <summary>
        ///     Initializes a new <see cref="ClientInternalException" /> instance.
        /// </summary>
        public ClientInternalException() {}

        /// <summary>
        ///     Initializes a new <see cref="ClientInternalException" /> instance with a specified error message.
        /// </summary>
        public ClientInternalException(string message) : base(message) {}

        /// <summary>
        ///     Indicates that this exception is due to an internal client error
        /// </summary>
        public override bool IsClientInternal
        {
            get { return true; }
        }

    }
}
