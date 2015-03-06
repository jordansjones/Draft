using System;
using System.Linq;

namespace Draft.Exceptions
{
    /// <summary>
    ///     Represents an error where the event in the requested index is outdated and cleared.
    /// </summary>
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
        ///     Indicates that this exception is due to the event in the requested index is outdated and cleared.
        /// </summary>
        public override bool IsEventIndexCleared
        {
            get { return true; }
        }

    }
}
