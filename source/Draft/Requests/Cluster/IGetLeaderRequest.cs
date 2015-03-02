using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

using Draft.Responses.Cluster;

namespace Draft.Requests.Cluster
{
    /// <summary>
    ///     A request to retrieve the leader information for the cluster.
    /// </summary>
    public interface IGetLeaderRequest
    {

        /// <summary>
        ///     Execute this request.
        /// </summary>
        Task<IClusterMember> Execute();

        /// <summary>
        ///     Allows use of the <c>await</c> keyword for this request.
        /// </summary>
        TaskAwaiter<IClusterMember> GetAwaiter();

    }
}
