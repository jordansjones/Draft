using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

using Draft.Responses.Cluster;

namespace Draft.Requests.Cluster
{
    /// <summary>
    ///     A request to delete a member of the cluster.
    /// </summary>
    public interface IDeleteMemberRequest
    {

        /// <summary>
        ///     Execute this request.
        /// </summary>
        Task Execute();

        /// <summary>
        ///     Allows use of the <c>await</c> keyword for this request.
        /// </summary>
        TaskAwaiter GetAwaiter();

        /// <summary>
        ///     Unique identifier of the member to delete.
        /// </summary>
        /// <seealso cref="IClusterMember.Id" />
        IDeleteMemberRequest WithMemberId(string memberId);

    }
}
