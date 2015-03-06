using System;
using System.Linq;

namespace Draft.Exceptions
{
    /// <summary>
    ///     Represents an error where the etcd operation requires a value or ttl field, but neither was provided.
    /// </summary>
    public class ValueOrTtlRequiredException : EtcdException
    {

        /// <summary>
        ///     Initializes a new <see cref="ValueOrTtlRequiredException" /> instance.
        /// </summary>
        public ValueOrTtlRequiredException() {}

        /// <summary>
        ///     Initializes a new <see cref="ValueOrTtlRequiredException" /> instance with a specified error message.
        /// </summary>
        public ValueOrTtlRequiredException(string message) : base(message) {}

        public override bool IsValueOrTtlRequired
        {
            get { return true; }
        }

    }
}
