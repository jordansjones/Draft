using System;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Draft.Exceptions
{
    /// <summary>
    ///     Represents an error where etcd was unable to parse the passed ttl value into a number.
    /// </summary>
    [Serializable]
    public class TtlNotANumberException : EtcdException
    {

        /// <summary>
        ///     Initializes a new <see cref="TtlNotANumberException" /> instance.
        /// </summary>
        public TtlNotANumberException() {}

        /// <summary>
        ///     Initializes a new <see cref="TtlNotANumberException" /> instance with a specified error message.
        /// </summary>
        public TtlNotANumberException(string message) : base(message) {}
        
        /// <summary>
        ///     Initializes a new <see cref="TtlNotANumberException" /> instance for use in BCL deserialization
        /// </summary>
        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        protected TtlNotANumberException(SerializationInfo info, StreamingContext context) : base(info, context) {}

        /// <summary>
        ///     Indicates that this exception is due to etcd being unable to parse the passed ttl value as a number.
        /// </summary>
        public override bool IsTtlNotANumber
        {
            get { return true; }
        }

    }
}
