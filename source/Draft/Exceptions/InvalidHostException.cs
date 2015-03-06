using System;
using System.Linq;

namespace Draft.Exceptions
{
    /// <summary>
    ///     Represents an error when attempting to connect to a non-etcd endpoint.
    /// </summary>
    public class InvalidHostException : EtcdException
    {

        /// <summary>
        ///     Initializes a new <see cref="InvalidHostException" /> instance.
        /// </summary>
        public InvalidHostException() {}

        /// <summary>
        ///     Initializes a new <see cref="InvalidHostException" /> instance with a specified error message.
        /// </summary>
        public InvalidHostException(string message) : base(message) {}

        public override bool IsInvalidHost
        {
            get { return true; }
        }

    }
}
