using System;
using System.Linq;

namespace Draft.Responses.Statistics
{
    /// <summary>
    ///     Various statistics about a follower in an etcd cluster
    /// </summary>
    public interface IFollowerStatistics
    {

        /// <summary>
        ///     Follower send counts
        /// </summary>
        IFollowerCounts Counts { get; }

        /// <summary>
        ///     Follower latency statistics
        /// </summary>
        IFollowerLatency Latency { get; }

    }
}
