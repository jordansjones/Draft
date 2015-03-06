using System;
using System.Linq;

namespace Draft.Exceptions
{
    /// <summary>
    ///     Represents an error where the etcd operation requires an index or value parameter, but both was provided.
    /// </summary>
    public class IndexValueMutexException : EtcdException
    {

        /// <summary>
        ///     Initializes a new <see cref="IndexValueMutexException" /> instance.
        /// </summary>
        public IndexValueMutexException() {}

        /// <summary>
        ///     Initializes a new <see cref="IndexValueMutexException" /> instance with a specified error message.
        /// </summary>
        public IndexValueMutexException(string message) : base(message) {}

        public override bool IsIndexValueMutex
        {
            get { return true; }
        }

    }
}
