using System;
using System.Linq;
using System.Runtime.Serialization;

namespace Draft.Responses.Statistics
{
    /// <summary>
    ///     Statistical information on an etcd server member
    /// </summary>
    [DataContract]
    internal class ServerStatistics : IServerStatistics
    {

        /// <summary>
        ///     The unique identifier for this server member
        /// </summary>
        [DataMember(Name = "id")]
        public string Id { get; set; }

        /// <summary>
        ///     Statistical information for this server member's leader
        /// </summary>
        [DataMember(Name = "leaderInfo")]
        public LeaderInfo LeaderInfo { get; set; }

        [IgnoreDataMember]
        ILeaderInfo IServerStatistics.LeaderInfo
        {
            get { return LeaderInfo; }
        }

        /// <summary>
        ///     The name for this server member
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        ///     Number of append requests this server member has processed
        /// </summary>
        [DataMember(Name = "recvAppendRequestCnt")]
        public long ReceivedAppendRequestCount { get; set; }

        /// <summary>
        ///     Number of bytes per second this server member is receiving (follower state only)
        /// </summary>
        [DataMember(Name = "recvBandwidthRate")]
        public double? ReceivedBandwidthRate { get; set; }

        /// <summary>
        ///     Number of requests per second this server member is receiving (follower state only)
        /// </summary>
        [DataMember(Name = "recvPkgRate")]
        public double? ReceivedPackageRate { get; set; }

        /// <summary>
        ///     Numer of requests this server member has sent
        /// </summary>
        [DataMember(Name = "sendAppendRequestCnt")]
        public long SendAppendRequestCount { get; set; }

        /// <summary>
        ///     Number of bytes per second this server member is sending (leader state only)
        /// </summary>
        /// <remarks>
        ///     This value is null on single member clusters
        /// </remarks>
        [DataMember(Name = "sendBandwidthRate")]
        public double? SendBandwidthRate { get; set; }

        /// <summary>
        ///     Number of requests per second this server member is sending (leader state only)
        /// </summary>
        /// <remarks>
        ///     This value is null on single member clusters
        /// </remarks>
        [DataMember(Name = "sendPkgRate")]
        public double? SendPackageRate { get; set; }

        /// <summary>
        ///     The time when this server member was started
        /// </summary>
        [DataMember(Name = "startTime")]
        public DateTime StartTime { get; set; }

        /// <summary>
        ///     The cluster state for this server member
        /// </summary>
        [DataMember(Name = "state")]
        public StateType State { get; set; }

    }
}
