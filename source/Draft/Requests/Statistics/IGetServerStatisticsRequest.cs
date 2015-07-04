using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

using Draft.Endpoints;
using Draft.Responses.Statistics;

namespace Draft.Requests.Statistics
{
    /// <summary>
    ///     A request to retrieve the statistical information for the server.
    /// </summary>
    /// <remarks>Which server depends on how the <see cref="EndpointPool" /> was built.</remarks>
    public interface IGetServerStatisticsRequest
    {

        /// <summary>
        ///     The underlying <see cref="IEtcdClient" /> for this request.
        /// </summary>
        IEtcdClient EtcdClient { get; }

        /// <summary>
        ///     Execute this request.
        /// </summary>
        Task<IServerStatistics> Execute();

        /// <summary>
        ///     Allows use of the <c>await</c> keyword for this request.
        /// </summary>
        TaskAwaiter<IServerStatistics> GetAwaiter();

    }
}
