using System;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Draft.Exceptions
{
    /// <summary>
    ///     Represents an error where etcd was unable parse the passed index value into a number.
    /// </summary>
    [Serializable]
    public class IndexNotANumberException : EtcdException
    {

        /// <summary>
        ///     Initializes a new <see cref="IndexNotANumberException" /> instance.
        /// </summary>
        public IndexNotANumberException() {}

        /// <summary>
        ///     Initializes a new <see cref="IndexNotANumberException" /> instance with a specified error message.
        /// </summary>
        public IndexNotANumberException(string message) : base(message) {}
        
        /// <summary>
        ///     Initializes a new <see cref="IndexNotANumberException" /> instance for use in BCL deserialization
        /// </summary>
        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        protected IndexNotANumberException(SerializationInfo info, StreamingContext context) : base(info, context) {}

        /// <summary>
        ///     Indicates that this exception is due to etcd being unable to parse the passed index value as a number.
        /// </summary>
        public override bool IsIndexNotANumber
        {
            get { return true; }
        }

    }
}
