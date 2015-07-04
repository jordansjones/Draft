using System;
using System.Linq;
using System.Runtime.Serialization;

namespace Draft.Responses.Statistics
{
    /// <summary>
    ///     Various statistics about a follower in an etcd cluster
    /// </summary>
    [DataContract]
    internal class FollowerStatistics : IFollowerStatistics
    {

        IFollowerCounts IFollowerStatistics.Counts
        {
            get { return Counts; }
        }

        /// <summary>
        ///     Follower send counts
        /// </summary>
        [DataMember(Name = "counts")]
        public FollowerCounts Counts { get; set; }

        IFollowerLatency IFollowerStatistics.Latency
        {
            get { return Latency; }
        }

        /// <summary>
        ///     Follower latency statistics
        /// </summary>
        [DataMember(Name = "latency")]
        public FollowerLatency Latency { get; set; }

    }

}
