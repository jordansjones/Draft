using System;
using System.Linq;

namespace Draft.Exceptions
{
    /// <summary>
    ///     Represents an error when attempting to modify the root keyspace.
    /// </summary>
    public class RootIsReadOnlyException : EtcdException
    {

        /// <summary>
        ///     Initializes a new <see cref="RootIsReadOnlyException" /> instance.
        /// </summary>
        public RootIsReadOnlyException() {}

        /// <summary>
        ///     Initializes a new <see cref="RootIsReadOnlyException" /> instance with a specified error message.
        /// </summary>
        public RootIsReadOnlyException(string message) : base(message) {}

        public override bool IsRootReadOnly
        {
            get { return true; }
        }

    }
}
