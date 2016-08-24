using System;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Draft.Exceptions
{
    /// <summary>
    ///     Represents an error where the event in the requested index is outdated and cleared.
    /// </summary>
    [Serializable]
    public class EventIndexClearedException : EtcdException
    {

        /// <summary>
        ///     Initializes a new <see cref="EventIndexClearedException" /> instance.
        /// </summary>
        public EventIndexClearedException() {}

        /// <summary>
        ///     Initializes a new <see cref="EventIndexClearedException" /> instance with a specified error message.
        /// </summary>
        public EventIndexClearedException(string message) : base(message) {}

        /// <summary>
        ///     Initializes a new <see cref="EventIndexClearedException" /> instance for use in BCL deserialization
        /// </summary>
        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        protected EventIndexClearedException(SerializationInfo info, StreamingContext context) : base(info, context) {}

        /// <summary>
        ///     Indicates that this exception is due to the event in the requested index is outdated and cleared.
        /// </summary>
        public override bool IsEventIndexCleared
        {
            get { return true; }
        }

    }
}
