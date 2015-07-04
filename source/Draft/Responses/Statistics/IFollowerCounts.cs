using System;
using System.Linq;

namespace Draft.Responses.Statistics
{
    /// <summary>
    ///     Follower send counts
    /// </summary>
    public interface IFollowerCounts
    {

        /// <summary>
        ///     Count of unsuccessful sends
        /// </summary>
        long Fail { get; }

        /// <summary>
        ///     Count of successful sends
        /// </summary>
        long Success { get; }

    }
}
