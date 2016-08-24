using System;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Draft.Exceptions
{
    /// <summary>
    ///     Represents a file based operation on a key that isn't a file error.
    /// </summary>
    [Serializable]
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
        ///     Initializes a new <see cref="NotAFileException" /> instance for use in BCL deserialization
        /// </summary>
        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        protected NotAFileException(SerializationInfo info, StreamingContext context) : base(info, context) {}

        /// <summary>
        ///     Indicates that this exception is due to attempting a file based operation on a key that isn't a file.
        /// </summary>
        public override bool IsNotFile
        {
            get { return true; }
        }

    }
}
