using System;
using System.Linq;

namespace Draft.Exceptions
{
    /// <summary>
    ///     Represents an error when attempting to use an etcd reserved keyword as a key in a key based operation.
    /// </summary>
    public class KeyIsPreservedException : EtcdException
    {

        /// <summary>
        ///     Initializes a new <see cref="KeyIsPreservedException" /> instance.
        /// </summary>
        public KeyIsPreservedException() {}

        /// <summary>
        ///     Initializes a new <see cref="KeyIsPreservedException" /> instance with a specified error message.
        /// </summary>
        public KeyIsPreservedException(string message) : base(message) {}

        public override bool IsKeyIsPreserved
        {
            get { return true; }
        }

    }
}
