using System;
using System.Linq;
using System.Runtime.Serialization;

namespace Draft.Responses.Statistics
{
    /// <summary>
    ///     Statistical information for a member server's leader
    /// </summary>
    [DataContract]
    internal class LeaderInfo : ILeaderInfo
    {

        /// <summary>
        ///     Id of the current leader
        /// </summary>
        [DataMember(Name = "leader")]
        public string Leader { get; set; }

        /// <summary>
        ///     Time when the leader was started (if available)
        /// </summary>
        [DataMember(Name = "startTime")]
        public DateTime? StartTime { get; set; }

        /// <summary>
        ///     String representation of the amount of time the leader has been leader
        /// </summary>
        [DataMember(Name = "uptime")]
        public string Uptime { get; set; }

    }

}
