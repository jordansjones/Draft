using System;
using System.Linq;

namespace Draft.Responses.Statistics
{
    /// <summary>
    ///     Statistical information on an etcd server member
    /// </summary>
    public interface IServerStatistics
    {

        /// <summary>
        ///     The unique identifier for this server member
        /// </summary>
        string Id { get; }

        /// <summary>
        ///     Statistical information for this server member's leader
        /// </summary>
        ILeaderInfo LeaderInfo { get; }

        /// <summary>
        ///     The name for this server member
        /// </summary>
        string Name { get; }

        /// <summary>
        ///     Number of append requests this server member has processed
        /// </summary>
        long ReceivedAppendRequestCount { get; }

        /// <summary>
        ///     Number of bytes per second this server member is receiving (follower state only)
        /// </summary>
        double? ReceivedBandwidthRate { get; }

        /// <summary>
        ///     Number of requests per second this server member is receiving (follower state only)
        /// </summary>
        double? ReceivedPackageRate { get; }

        /// <summary>
        ///     Numer of requests this server member has sent
        /// </summary>
        long SendAppendRequestCount { get; }

        /// <summary>
        ///     Number of bytes per second this server member is sending (leader state only)
        /// </summary>
        /// <remarks>
        ///     This value is null on single member clusters
        /// </remarks>
        double? SendBandwidthRate { get; }

        /// <summary>
        ///     Number of requests per second this server member is sending (leader state only)
        /// </summary>
        /// <remarks>
        ///     This value is null on single member clusters
        /// </remarks>
        double? SendPackageRate { get; }

        /// <summary>
        ///     The time when this server member was started
        /// </summary>
        DateTime StartTime { get; }

        /// <summary>
        ///     The cluster state for this server member
        /// </summary>
        StateType State { get; }

    }
}
