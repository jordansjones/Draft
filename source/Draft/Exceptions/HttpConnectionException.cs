using System;
using System.Linq;

namespace Draft.Exceptions
{
    /// <summary>
    ///     Represents an error with the underlying http client when attempting to connect to an etcd endpoint.
    /// </summary>
    public class HttpConnectionException : EtcdException
    {

        /// <summary>
        ///     Initializes a new <see cref="HttpConnectionException" /> instance.
        /// </summary>
        public HttpConnectionException() {}

        /// <summary>
        ///     Initializes a new <see cref="HttpConnectionException" /> instance with a specified error message.
        /// </summary>
        public HttpConnectionException(string message) : base(message) {}

        /// <summary>
        ///     Indicates that this exception is due to an underlying http client connection error.
        /// </summary>
        public override bool IsHttpConnection
        {
            get { return true; }
        }

    }
}
