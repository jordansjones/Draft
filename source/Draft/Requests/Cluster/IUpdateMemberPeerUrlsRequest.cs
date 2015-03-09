using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

using Draft.Responses.Cluster;

namespace Draft.Requests.Cluster
{
    /// <summary>
    ///     A request to update a cluster member's peer url list.
    /// </summary>
    public interface IUpdateMemberPeerUrlsRequest
    {

        /// <summary>
        ///     The underlying <see cref="IEtcdClient" /> for this request.
        /// </summary>
        IEtcdClient EtcdClient { get; }

        /// <summary>
        ///     Execute this request.
        /// </summary>
        Task<IClusterMember> Execute();

        /// <summary>
        ///     Allows use of the <c>await</c> keyword for this request.
        /// </summary>
        TaskAwaiter<IClusterMember> GetAwaiter();

        /// <summary>
        ///     Unique identifier of the member to delete.
        /// </summary>
        /// <seealso cref="IClusterMember.Id" />
        IUpdateMemberPeerUrlsRequest WithMemberId(string memberId);

        /// <summary>
        ///     Peer endpoints for this member.
        /// </summary>
        IUpdateMemberPeerUrlsRequest WithPeerUri(params Uri[] uris);

    }
}
