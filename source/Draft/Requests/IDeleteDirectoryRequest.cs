using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

using Draft.Responses;

namespace Draft.Requests
{
    /// <summary>
    ///     A request to delete a directory with the specified path.
    /// </summary>
    public interface IDeleteDirectoryRequest
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
        ///     When <c>true</c>, also delete all child nodes.
        /// </summary>
        IDeleteDirectoryRequest WithRecursive(bool recursive = true);

    }
}
