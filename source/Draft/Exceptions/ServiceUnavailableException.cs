using System;
using System.Linq;

namespace Draft.Exceptions
{
    /// <summary>
    ///     Represents a "Service unavailable error".
    /// </summary>
    public class ServiceUnavailableException : EtcdException
    {

        /// <summary>
        ///     Initializes a new <see cref="ServiceUnavailableException" /> instance.
        /// </summary>
        public ServiceUnavailableException() {}

        /// <summary>
        ///     Initializes a new <see cref="ServiceUnavailableException" /> instance with a specified error message.
        /// </summary>
        public ServiceUnavailableException(string message) : base(message) {}

        /// <summary>
        ///     Indicates that this exception is due to a general problem with the request to etcd.
        /// </summary>
        public override bool IsServiceUnavailable
        {
            get { return true; }
        }

    }
}
