using System;
using System.Linq;

namespace Draft.Exceptions
{
    /// <summary>
    ///     Represents an error due to a pre-existing key.
    /// </summary>
    public class NodeExistsException : EtcdException
    {

        /// <summary>
        ///     Initializes a new <see cref="NodeExistsException" /> instance.
        /// </summary>
        public NodeExistsException() {}

        /// <summary>
        ///     Initializes a new <see cref="NodeExistsException" /> instance with a specified error message.
        /// </summary>
        public NodeExistsException(string message) : base(message) {}

        public override bool IsNodeExists
        {
            get { return true; }
        }

    }
}
