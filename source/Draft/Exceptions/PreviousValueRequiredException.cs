using System;
using System.Linq;

namespace Draft.Exceptions
{
    /// <summary>
    ///     Represents an error where the operation requires as previous value, but was missing in the form post.
    /// </summary>
    public class PreviousValueRequiredException : EtcdException
    {

        /// <summary>
        ///     Initializes a new <see cref="PreviousValueRequiredException" /> instance.
        /// </summary>
        public PreviousValueRequiredException() {}

        /// <summary>
        ///     Initializes a new <see cref="PreviousValueRequiredException" /> instance with a specified error message.
        /// </summary>
        public PreviousValueRequiredException(string message) : base(message) {}

        /// <summary>
        ///     Indicates that this exception is due to the previous value field missing in the form post.
        /// </summary>
        public override bool IsPreviousValueRequired
        {
            get { return true; }
        }

    }
}
