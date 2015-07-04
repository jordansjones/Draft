using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

using Draft.Endpoints;
using Draft.Responses.Statistics;

namespace Draft.Requests.Statistics
{
    /// <summary>
    ///     A request to retrieve the etcd backing store statistics.
    /// </summary>
    /// <remarks>For which server depends on how the <see cref="EndpointPool" /> was built.</remarks>
    public interface IGetStoreStatisticsRequest
    {

        /// <summary>
        ///     The underlying <see cref="IEtcdClient" /> for this request.
        /// </summary>
        IEtcdClient EtcdClient { get; }

        /// <summary>
        ///     Execute this request.
        /// </summary>
        Task<IStoreStatistics> Execute();

        /// <summary>
        ///     Allows use of the <c>await</c> keyword for this request.
        /// </summary>
        TaskAwaiter<IStoreStatistics> GetAwaiter();

    }
}
