using System;
using System.Linq;

namespace Draft.Exceptions
{
    /// <summary>
    ///     Represents a "Standby remove delay" error.
    /// </summary>
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
        ///     Indicates that this exception is due to a "Standby remove delay" error.
        /// </summary>
        public override bool IsInvalidRemoveDelay
        {
            get { return true; }
        }

    }
}
