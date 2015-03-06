using System;
using System.Linq;

namespace Draft.Exceptions
{
    /// <summary>
    ///     Etcd key not found exception
    /// </summary>
    public class KeyNotFoundException : EtcdException
    {

        /// <summary>
        ///     Initializes a new <see cref="KeyNotFoundException" /> instance.
        /// </summary>
        public KeyNotFoundException() {}

        /// <summary>
        ///     Initializes a new <see cref="KeyNotFoundException" /> instance with a specified error message.
        /// </summary>
        public KeyNotFoundException(string message) : base(message) {}

        public override bool IsKeyNotFound
        {
            get { return true; }
        }

    }
}
