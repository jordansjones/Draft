using System;
using System.Linq;
using System.Runtime.Serialization;

namespace Draft.Responses.Statistics
{
    /// <summary>
    ///     Represents the leadership type of a member of a cluster
    /// </summary>
    [DataContract]
    public enum StateType
    {

        /// <summary>
        ///     Unable to parse
        /// </summary>
        Unknown,

        /// <summary>
        ///     StateFollower
        /// </summary>
        [EnumMember(Value = "StateFollower")]
        StateFollower,

        /// <summary>
        ///     StateCandidate
        /// </summary>
        [EnumMember(Value = "StateCandidate")]
        StateCandidate,

        /// <summary>
        ///     StateLeader
        /// </summary>
        [EnumMember(Value = "StateLeader")]
        StateLeader

    }
}
