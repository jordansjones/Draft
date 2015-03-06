using System;
using System.Linq;

namespace Draft.Exceptions
{
    /// <summary>
    ///     Represents a file based operation on a key that isn't a file error.
    /// </summary>
    public class NotAFileException : EtcdException
    {

        /// <summary>
        ///     Initializes a new <see cref="NotAFileException" /> instance.
        /// </summary>
        public NotAFileException() {}

        /// <summary>
        ///     Initializes a new <see cref="NotAFileException" /> instance with a specified error message.
        /// </summary>
        public NotAFileException(string message) : base(message) {}

        /// <summary>
        ///     Indicates that this exception is due to attempting a file based operation on a key that isn't a file.
        /// </summary>
        public override bool IsNotFile
        {
            get { return true; }
        }

    }
}
