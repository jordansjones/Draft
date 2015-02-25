using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Draft.Requests
{
    public interface IDeleteDirectoryRequest
    {

        Task<object> Execute();

        TaskAwaiter<object> GetAwaiter();

        IDeleteDirectoryRequest WithCancellationToken(CancellationToken token);

    }
}
