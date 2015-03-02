using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

using Draft.Responses;

namespace Draft.Requests
{
    /// <summary>
    ///     A request to create a directory with the specified path.
    /// </summary>
    public interface ICreateDirectoryRequest
    {

        /// <summary>
        ///     Execute this request.
        /// </summary>
        Task<IKeyEvent> Execute();

        /// <summary>
        ///     Allows use of the <c>await</c> keyword for this request.
        /// </summary>
        TaskAwaiter<IKeyEvent> GetAwaiter();

        /// <summary>
        ///     An optional expiration for this directory.
        /// </summary>
        ICreateDirectoryRequest WithTimeToLive(long? seconds = 0);

    }

}
