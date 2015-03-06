using System;
using System.Linq;

namespace Draft.Exceptions
{
    /// <summary>
    ///     Represents an error where the etcd operation requires an index or value parameter, but neither was provided.
    /// </summary>
    public class IndexOrValueRequiredException : EtcdException
    {

        /// <summary>
        ///     Initializes a new <see cref="IndexOrValueRequiredException" /> instance.
        /// </summary>
        public IndexOrValueRequiredException() {}

        /// <summary>
        ///     Initializes a new <see cref="IndexOrValueRequiredException" /> instance with a specified error message.
        /// </summary>
        public IndexOrValueRequiredException(string message) : base(message) {}

        public override bool IsIndexOrValueRequired
        {
            get { return true; }
        }

    }
}
