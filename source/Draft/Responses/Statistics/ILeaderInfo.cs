using System;
using System.Linq;

namespace Draft.Responses.Statistics
{
    /// <summary>
    ///     Statistical information for a member server's leader
    /// </summary>
    public interface ILeaderInfo
    {

        /// <summary>
        ///     Id of the current leader
        /// </summary>
        string Leader { get; }

        /// <summary>
        ///     Time when the leader was started (if available)
        /// </summary>
        DateTime? StartTime { get; }

        /// <summary>
        ///     String representation of the amount of time the leader has been leader
        /// </summary>
        string Uptime { get; }

    }
}
