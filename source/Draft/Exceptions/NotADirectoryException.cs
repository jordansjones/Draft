using System;
using System.Linq;

namespace Draft.Exceptions
{
    /// <summary>
    ///     Represents a directory based operation on a non directory key error.
    /// </summary>
    public class NotADirectoryException : EtcdException
    {

        /// <summary>
        ///     Initializes a new <see cref="NotADirectoryException" /> instance.
        /// </summary>
        public NotADirectoryException() {}

        /// <summary>
        ///     Initializes a new <see cref="NotADirectoryException" /> instance with a specified error message.
        /// </summary>
        public NotADirectoryException(string message) : base(message) {}

        /// <summary>
        ///     Indicates that this exception is due to attempting a directory based operation on a key that isn't a directory.
        /// </summary>
        public override bool IsNotDirectory
        {
            get { return true; }
        }

    }
}
