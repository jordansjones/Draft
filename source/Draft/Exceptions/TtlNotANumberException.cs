using System;
using System.Linq;

namespace Draft.Exceptions
{
    /// <summary>
    ///     Represents an error where etcd was unable to parse the passed ttl value into a number.
    /// </summary>
    public class TtlNotANumberException : EtcdException
    {

        /// <summary>
        ///     Initializes a new <see cref="TtlNotANumberException" /> instance.
        /// </summary>
        public TtlNotANumberException() {}

        /// <summary>
        ///     Initializes a new <see cref="TtlNotANumberException" /> instance with a specified error message.
        /// </summary>
        public TtlNotANumberException(string message) : base(message) {}

        public override bool IsTtlNotANumber
        {
            get { return true; }
        }

    }
}
