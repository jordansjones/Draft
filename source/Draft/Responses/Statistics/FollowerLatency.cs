using System;
using System.Linq;
using System.Runtime.Serialization;

namespace Draft.Responses.Statistics
{
    /// <summary>
    ///     Follower latency statistics
    /// </summary>
    [DataContract]
    internal class FollowerLatency : IFollowerLatency
    {

        /// <summary>
        ///     Follower's average latency
        /// </summary>
        [DataMember(Name = "average")]
        public double Average { get; set; }

        /// <summary>
        ///     Follower's current latency
        /// </summary>
        [DataMember(Name = "current")]
        public double Current { get; set; }

        /// <summary>
        ///     Follower's maximum latency
        /// </summary>
        [DataMember(Name = "maximum")]
        public double Maximum { get; set; }

        /// <summary>
        ///     Follower's minimum latency
        /// </summary>
        [DataMember(Name = "minimum")]
        public double Minimum { get; set; }

        /// <summary>
        ///     Standard Deviation
        /// </summary>
        [DataMember(Name = "standardDeviation")]
        public double StandardDeviation { get; set; }

    }
}
