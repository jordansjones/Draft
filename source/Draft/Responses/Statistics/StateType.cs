using System;
using System.Linq;

namespace Draft.Responses.Statistics
{
    /// <summary>
    /// Represents the leadership type of a member of a cluster
    /// </summary>
    public enum StateType
    {

        /// <summary>
        /// Unable to parse
        /// </summary>
        Unknown,

        /// <summary>
        /// StateFollower
        /// </summary>
        Follower,

        /// <summary>
        /// StateCandidate
        /// </summary>
        Candidate,

        /// <summary>
        /// StateLeader
        /// </summary>
        Leader

    }
}
