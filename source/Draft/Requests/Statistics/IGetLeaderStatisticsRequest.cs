using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

using Draft.Responses.Statistics;

namespace Draft.Requests.Statistics
{
    /// <summary>
    ///     A request to retrieve the statistical information for the leader in an etcd cluster.
    /// </summary>
    public interface IGetLeaderStatisticsRequest
    {

        /// <summary>
        ///     The underlying <see cref="IEtcdClient" /> for this request.
        /// </summary>
        IEtcdClient EtcdClient { get; }

        /// <summary>
        ///     Execute this request.
        /// </summary>
        Task<ILeaderStatistics> Execute();

        /// <summary>
        ///     Allows use of the <c>await</c> keyword for this request.
        /// </summary>
        TaskAwaiter<ILeaderStatistics> GetAwaiter();

    }
}
