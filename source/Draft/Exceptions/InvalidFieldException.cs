using System;
using System.Linq;

namespace Draft.Exceptions
{
    /// <summary>
    ///     Represents an error where the operation was passed an invalid field value.
    /// </summary>
    public class InvalidFieldException : EtcdException
    {

        /// <summary>
        ///     Initializes a new <see cref="InvalidFieldException" /> instance.
        /// </summary>
        public InvalidFieldException() {}

        /// <summary>
        ///     Initializes a new <see cref="InvalidFieldException" /> instance with a specified error message.
        /// </summary>
        public InvalidFieldException(string message) : base(message) {}

        public override bool IsInvalidField
        {
            get { return true; }
        }

    }
}
