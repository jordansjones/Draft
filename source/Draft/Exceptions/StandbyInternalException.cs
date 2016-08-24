using System;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Draft.Exceptions
{
    /// <summary>
    ///     Represents an "Internal standby error".
    /// </summary>
    [Serializable]
    public class StandbyInternalException : EtcdException
    {

        /// <summary>
        ///     Initializes a new <see cref="StandbyInternalException" /> instance.
        /// </summary>
        public StandbyInternalException() {}

        /// <summary>
        ///     Initializes a new <see cref="StandbyInternalException" /> instance with a specified error message.
        /// </summary>
        public StandbyInternalException(string message) : base(message) {}
        
        /// <summary>
        ///     Initializes a new <see cref="StandbyInternalException" /> instance for use in BCL deserialization
        /// </summary>
        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        protected StandbyInternalException(SerializationInfo info, StreamingContext context) : base(info, context) {}

        /// <summary>
        ///     Indicates that this exception is due to an "Internal standby error".
        /// </summary>
        public override bool IsStandbyInternal
        {
            get { return true; }
        }

    }
}
