using System;
using System.Linq;

namespace Draft.Exceptions
{
    /// <summary>
    ///     Represents an error where the etcd operation requires a name field, but one was not provided.
    /// </summary>
    public class NameRequiredException : EtcdException
    {

        /// <summary>
        ///     Initializes a new <see cref="NameRequiredException" /> instance.
        /// </summary>
        public NameRequiredException() {}

        /// <summary>
        ///     Initializes a new <see cref="NameRequiredException" /> instance with a specified error message.
        /// </summary>
        public NameRequiredException(string message) : base(message) {}

        public override bool IsNameRequired
        {
            get { return true; }
        }

    }
}
