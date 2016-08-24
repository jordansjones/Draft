using System;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Draft.Exceptions
{
    /// <summary>
    ///     Represents an error due to the watcher being cleared as a result of etcd recovery.
    /// </summary>
    [Serializable]
    public class WatcherClearedException : EtcdException
    {

        /// <summary>
        ///     Initializes a new <see cref="WatcherClearedException" /> instance.
        /// </summary>
        public WatcherClearedException() {}

        /// <summary>
        ///     Initializes a new <see cref="WatcherClearedException" /> instance with a specified error message.
        /// </summary>
        public WatcherClearedException(string message) : base(message) {}
        
        /// <summary>
        ///     Initializes a new <see cref="WatcherClearedException" /> instance for use in BCL deserialization
        /// </summary>
        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        protected WatcherClearedException(SerializationInfo info, StreamingContext context) : base(info, context) {}

        /// <summary>
        ///     Indicates that this exception is due to the watcher being cleared as a result of etcd recovery.
        /// </summary>
        public override bool IsWatcherCleared
        {
            get { return true; }
        }

    }
}
