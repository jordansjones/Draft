using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

using Draft.Responses.Cluster;

namespace Draft.Requests.Cluster
{
    /// <summary>
    ///     A request to create a new member of the cluster.
    /// </summary>
    public interface ICreateMemberRequest
    {

        /// <summary>
        ///     Execute this request.
        /// </summary>
        Task<IClusterMember> Execute();

        /// <summary>
        ///     Allows use of the <c>await</c> keyword for this request.
        /// </summary>
        TaskAwaiter<IClusterMember> GetAwaiter();

        /// <summary>
        ///     Name for the member.
        /// </summary>
        ICreateMemberRequest WithName(string name);

        /// <summary>
        ///     Peer endpoints for the member.
        /// </summary>
        ICreateMemberRequest WithPeerUri(params Uri[] uris);

    }
}
