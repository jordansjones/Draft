using System;
using System.Linq;

namespace Draft.Exceptions
{
    /// <summary>
    ///     Represents an error where an invalid form was posted for the etcd operation.
    /// </summary>
    public class InvalidFormException : EtcdException
    {

        /// <summary>
        ///     Initializes a new <see cref="InvalidFormException" /> instance.
        /// </summary>
        public InvalidFormException() {}

        /// <summary>
        ///     Initializes a new <see cref="InvalidFormException" /> instance with a specified error message.
        /// </summary>
        public InvalidFormException(string message) : base(message) {}

        public override bool IsInvalidForm
        {
            get { return true; }
        }

    }
}
