using System;
using System.Collections.Generic;
using System.Linq;

namespace Draft.Responses.Statistics
{
    /// <summary>
    ///     Statistics about communication with cluster members
    /// </summary>
    public interface ILeaderStatistics
    {

        /// <summary>
        ///     Map of cluster member id's to cluster member statistics
        /// </summary>
        IReadOnlyDictionary<string, IFollowerStatistics> Followers { get; }

        /// <summary>
        ///     Id for the currently elected cluster leader
        /// </summary>
        string Leader { get; }

    }
}
