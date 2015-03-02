using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

using Draft.Responses.Cluster;

namespace Draft.Requests.Cluster
{
    /// <summary>
    ///     A request to retrieve member information for all members in the cluster.
    /// </summary>
    public interface IGetMembersRequest
    {

        /// <summary>
        ///     Execute this request.
        /// </summary>
        Task<IClusterMember[]> Execute();

        /// <summary>
        ///     Allows use of the <c>await</c> keyword for this request.
        /// </summary>
        TaskAwaiter<IClusterMember[]> GetAwaiter();

    }
}
