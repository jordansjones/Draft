using System;
using System.Linq;

namespace Draft.Responses.Statistics
{
    /// <summary>
    ///     Follower latency statistics
    /// </summary>
    public interface IFollowerLatency
    {

        /// <summary>
        ///     Follower's average latency
        /// </summary>
        double Average { get; }

        /// <summary>
        ///     Follower's current latency
        /// </summary>
        double Current { get; }

        /// <summary>
        ///     Follower's maximum latency
        /// </summary>
        double Maximum { get; }

        /// <summary>
        ///     Follower's minimum latency
        /// </summary>
        double Minimum { get; }

        /// <summary>
        ///     Standard Deviation
        /// </summary>
        double StandardDeviation { get; }

    }
}
