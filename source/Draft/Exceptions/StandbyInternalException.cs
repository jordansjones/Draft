using System;
using System.Linq;

namespace Draft.Exceptions
{
    /// <summary>
    ///     Represents an "Internal standby error".
    /// </summary>
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
        ///     Indicates that this exception is due to an "Internal standby error".
        /// </summary>
        public override bool IsStandbyInternal
        {
            get { return true; }
        }

    }
}
