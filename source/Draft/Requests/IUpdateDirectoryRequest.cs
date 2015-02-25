using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Draft.Requests
{
    public interface IUpdateDirectoryRequest
    {

        Task<object> Execute();

        TaskAwaiter<object> GetAwaiter();

        IUpdateDirectoryRequest WithCancellationToken(CancellationToken token);

        IUpdateDirectoryRequest WithTimeToLive(long? seconds = 0);

    }
}