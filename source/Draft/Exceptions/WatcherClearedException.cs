using System;
using System.Linq;

namespace Draft.Exceptions
{
    /// <summary>
    ///     Represents an error due to the watcher being cleared as a result of etcd recovery.
    /// </summary>
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

        public override bool IsWatcherCleared
        {
            get { return true; }
        }

    }
}
