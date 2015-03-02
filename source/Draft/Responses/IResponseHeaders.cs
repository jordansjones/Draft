using System;
using System.Linq;

namespace Draft.Responses
{
    /// <summary>
    ///     Provides global information about the etcd cluster that serviced a request
    /// </summary>
    public interface IResponseHeaders
    {

        /// <summary>
        ///     The unique identifier for the cluster.
        /// </summary>
        string ClusterId { get; }

        /// <summary>
        ///     The current etcd index
        /// </summary>
        long? CurrentIndex { get; }

        /// <summary>
        ///     Similar to the etcd index but is for the underlying raft protocol
        /// </summary>
        long? RaftIndex { get; }

        /// <summary>
        ///     Incrementing integer whenever an etcd master election happens
        /// </summary>
        /// <remarks>
        ///     If this number is increasing rapidly, election tuning may be needed
        /// </remarks>
        long? RaftTerm { get; }

    }
}
