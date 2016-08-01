using System.Runtime.CompilerServices;
using System.Threading.Tasks;

using Draft.Responses.Cluster;

namespace Draft.Requests.Cluster
{
    /// <summary>
    ///     A request to retrieve the health of the cluster.
    /// </summary>
    public interface IGetHealthRequest
    {

        /// <summary>
        ///     The underlying <see cref="IEtcdClient" /> for this request.
        /// </summary>
        IEtcdClient EtcdClient { get; }

        /// <summary>
        ///     Execute this request.
        /// </summary>
        Task<IHealthInfo> Execute();

        /// <summary>
        ///     Allows use of the <c>await</c> keyword for this request.
        /// </summary>
        TaskAwaiter<IHealthInfo> GetAwaiter();

    }
}