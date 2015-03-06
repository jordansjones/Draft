using System;
using System.Linq;

namespace Draft.Exceptions
{
    /// <summary>
    ///     Represents an atomic compare failure.
    /// </summary>
    public class TestFailedException : EtcdException
    {

        /// <summary>
        ///     Initializes a new <see cref="TestFailedException" /> instance.
        /// </summary>
        public TestFailedException() {}

        /// <summary>
        ///     Initializes a new <see cref="TestFailedException" /> instance with a specified error message.
        /// </summary>
        public TestFailedException(string message) : base(message) {}

        /// <summary>
        ///     Indicates that this exception is due to the compare test failing.
        /// </summary>
        public override bool IsTestFailed
        {
            get { return true; }
        }

    }
}
