using System;
using System.Linq;
using System.Runtime.Serialization;

namespace Draft.Models
{
    /// <summary>
    ///     Follower latency statistics
    /// </summary>
    [DataContract]
    public class FollowerLatency
    {

        /// <summary>
        ///     Follower's average latency
        /// </summary>
        [DataMember(Name = "average")]
        public double Average { get; private set; }

        /// <summary>
        ///     Follower's current latency
        /// </summary>
        [DataMember(Name = "current")]
        public double Current { get; private set; }

        /// <summary>
        ///     Follower's maximum latency
        /// </summary>
        [DataMember(Name = "maximum")]
        public double Maximum { get; private set; }

        /// <summary>
        ///     Follower's minimum latency
        /// </summary>
        [DataMember(Name = "minimum")]
        public double Minimum { get; private set; }

        /// <summary>
        ///     Standard Deviation
        /// </summary>
        [DataMember(Name = "standardDeviation")]
        public double StandardDeviation { get; private set; }

    }
}
