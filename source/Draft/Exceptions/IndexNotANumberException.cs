using System;
using System.Linq;

namespace Draft.Exceptions
{
    /// <summary>
    ///     Represents an error where etcd was unable parse the passed index value into a number.
    /// </summary>
    public class IndexNotANumberException : EtcdException
    {

        /// <summary>
        ///     Initializes a new <see cref="IndexNotANumberException" /> instance.
        /// </summary>
        public IndexNotANumberException() {}

        /// <summary>
        ///     Initializes a new <see cref="IndexNotANumberException" /> instance with a specified error message.
        /// </summary>
        public IndexNotANumberException(string message) : base(message) {}

        public override bool IsIndexNotANumber
        {
            get { return true; }
        }

    }
}
