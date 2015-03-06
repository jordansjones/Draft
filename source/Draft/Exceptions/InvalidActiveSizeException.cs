using System;
using System.Linq;

namespace Draft.Exceptions
{
    /// <summary>
    ///     Represents an "Invalid active size" error.
    /// </summary>
    public class InvalidActiveSizeException : EtcdException
    {

        /// <summary>
        ///     Initializes a new <see cref="InvalidActiveSizeException" /> instance.
        /// </summary>
        public InvalidActiveSizeException() {}

        /// <summary>
        ///     Initializes a new <see cref="InvalidActiveSizeException" /> instance with a specified error message.
        /// </summary>
        public InvalidActiveSizeException(string message) : base(message) {}

        public override bool IsInvalidActiveSize
        {
            get { return true; }
        }

    }
}
