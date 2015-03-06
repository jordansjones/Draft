using System;
using System.Linq;

namespace Draft.Exceptions
{
    /// <summary>
    ///     Represents an error in the etcd request.
    /// </summary>
    public class InvalidRequestException : EtcdException
    {

        /// <summary>
        ///     Initializes a new <see cref="InvalidRequestException" /> instance.
        /// </summary>
        public InvalidRequestException() {}

        /// <summary>
        ///     Initializes a new <see cref="InvalidRequestException" /> instance with a specified error message.
        /// </summary>
        public InvalidRequestException(string message) : base(message) {}


    }
}
