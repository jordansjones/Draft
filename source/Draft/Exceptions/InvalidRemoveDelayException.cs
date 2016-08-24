using System;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Draft.Exceptions
{
    /// <summary>
    ///     Represents a "Standby remove delay" error.
    /// </summary>
    [Serializable]
    public class InvalidRemoveDelayException : EtcdException
    {

        /// <summary>
        ///     Initializes a new <see cref="InvalidRemoveDelayException" /> instance.
        /// </summary>
        public InvalidRemoveDelayException() {}

        /// <summary>
        ///     Initializes a new <see cref="InvalidRemoveDelayException" /> instance with a specified error message.
        /// </summary>
        public InvalidRemoveDelayException(string message) : base(message) {}
        
        /// <summary>
        ///     Initializes a new <see cref="InvalidRemoveDelayException" /> instance for use in BCL deserialization
        /// </summary>
        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        protected InvalidRemoveDelayException(SerializationInfo info, StreamingContext context) : base(info, context) {}

        /// <summary>
        ///     Indicates that this exception is due to a "Standby remove delay" error.
        /// </summary>
        public override bool IsInvalidRemoveDelay
        {
            get { return true; }
        }

    }
}
