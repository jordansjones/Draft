using System;
using System.Linq;
using System.Runtime.Serialization;

namespace Draft.Responses.Statistics
{
    /// <summary>
    ///     Follower send counts
    /// </summary>
    [DataContract]
    internal class FollowerCounts
    {

        /// <summary>
        ///     Count of unsuccessful sends
        /// </summary>
        [DataMember(Name = "fail")]
        public long Fail { get; private set; }

        /// <summary>
        ///     Count of successful sends
        /// </summary>
        [DataMember(Name = "success")]
        public long Success { get; private set; }

    }
}
