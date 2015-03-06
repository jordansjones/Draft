using System;
using System.Linq;

namespace Draft.Exceptions
{
    /// <summary>
    ///     Represents an unknown error.
    /// </summary>
    public class UnknownErrorException : EtcdException
    {

        /// <summary>
        ///     Initializes a new <see cref="UnknownErrorException" /> instance.
        /// </summary>
        public UnknownErrorException() {}

        /// <summary>
        ///     Initializes a new <see cref="UnknownErrorException" /> instance with a specified error message.
        /// </summary>
        public UnknownErrorException(string message) : base(message) {}

        /// <summary>
        ///     Indicates that this exception is due to an unknown error.
        /// </summary>
        public override bool IsUnknown
        {
            get { return true; }
        }

    }
}
