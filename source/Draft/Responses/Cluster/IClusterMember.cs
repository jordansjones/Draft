using System;
using System.Linq;

namespace Draft.Responses.Cluster
{
    /// <summary>
    ///     Represents a member in the etcd cluster.
    /// </summary>
    public interface IClusterMember
    {

        /// <summary>
        ///     List of <see cref="Uri" />s this member listens on for client traffic.
        /// </summary>
        Uri[] ClientUrls { get; }

        /// <summary>
        ///     Unique identifier for this cluster member.
        /// </summary>
        string Id { get; }

        /// <summary>
        ///     Name for this cluster member.
        /// </summary>
        string Name { get; }

        /// <summary>
        ///     List of <see cref="Uri" />s this member listens on for peer traffic.
        /// </summary>
        Uri[] PeerUrls { get; }

    }
}
