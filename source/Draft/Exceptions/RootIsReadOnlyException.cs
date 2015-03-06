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

        /// <summary>
        ///     Indicates that this exception is due to the root keyspace being read only.
        /// </summary>
        /// <remarks>You probably tried to set a value on the root keyspace.</remarks>
        public override bool IsRootReadOnly
        {
            get { return true; }
        }

    }
}
