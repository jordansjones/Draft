using System;
using System.Linq;

namespace Draft.Exceptions
{
    /// <summary>
    ///     Represents an error where the value field was missing in the operation's form post.
    /// </summary>
    public class ValueRequiredException : EtcdException
    {

        /// <summary>
        ///     Initializes a new <see cref="ValueRequiredException" /> instance.
        /// </summary>
        public ValueRequiredException() {}

        /// <summary>
        ///     Initializes a new <see cref="ValueRequiredException" /> instance with a specified error message.
        /// </summary>
        public ValueRequiredException(string message) : base(message) {}

        public override bool IsValueRequired
        {
            get { return true; }
        }

    }
}
