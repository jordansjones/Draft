using System;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Draft.Exceptions
{
    /// <summary>
    ///     Represents an error where the directory operation failed due to still present children.
    /// </summary>
    [Serializable]
    public class DirectoryNotEmptyException : EtcdException
    {

        /// <summary>
        ///     Initializes a new <see cref="DirectoryNotEmptyException" /> instance.
        /// </summary>
        public DirectoryNotEmptyException() {}

        /// <summary>
        ///     Initializes a new <see cref="DirectoryNotEmptyException" /> instance with a specified error message.
        /// </summary>
        public DirectoryNotEmptyException(string message) : base(message) {}
        
        /// <summary>
        ///     Initializes a new <see cref="DirectoryNotEmptyException" /> instance for use in BCL deserialization
        /// </summary>
        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        protected DirectoryNotEmptyException(SerializationInfo info, StreamingContext context) : base(info, context) {}

        /// <summary>
        ///     Indicates that this exception is due to the passed directory still containing children.
        /// </summary>
        public override bool IsDirectoryNotEmpty
        {
            get { return true; }
        }

    }
}
