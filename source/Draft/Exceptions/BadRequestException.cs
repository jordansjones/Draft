using System;
using System.Linq;

namespace Draft.Exceptions
{
    /// <summary>
    ///     Represents a general problem with the requst to etcd.
    /// </summary>
    public class BadRequestException : EtcdException
    {

        /// <summary>
        ///     Initializes a new <see cref="BadRequestException" /> instance.
        /// </summary>
        public BadRequestException() {}

        /// <summary>
        ///     Initializes a new <see cref="BadRequestException" /> instance with a specified error message.
        /// </summary>
        public BadRequestException(string message) : base(message) {}

        /// <summary>
        ///     Indicates that this exception is due to a general problem with the request to etcd.
        /// </summary>
        public override bool IsBadRequest
        {
            get { return true; }
        }

    }
}
