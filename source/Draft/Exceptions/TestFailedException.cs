using System;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Draft.Exceptions
{
    /// <summary>
    ///     Represents an atomic compare failure.
    /// </summary>
    [Serializable]
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
        ///     Initializes a new <see cref="TestFailedException" /> instance for use in BCL deserialization
        /// </summary>
        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        protected TestFailedException(SerializationInfo info, StreamingContext context) : base(info, context) {}

        /// <summary>
        ///     Indicates that this exception is due to the compare test failing.
        /// </summary>
        public override bool IsTestFailed
        {
            get { return true; }
        }

    }
}
