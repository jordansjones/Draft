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

        public override bool IsNotDirectory
        {
            get { return true; }
        }

    }
}
