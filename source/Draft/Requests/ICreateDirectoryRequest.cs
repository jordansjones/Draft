using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Draft.Requests
{

    public interface ICreateDirectoryRequest
    {

        Task<object> Execute();

        TaskAwaiter<object> GetAwaiter();

        ICreateDirectoryRequest WithCancellationToken(CancellationToken token);

        ICreateDirectoryRequest WithExisting(bool existing = true);

        ICreateDirectoryRequest WithTimeToLive(long? seconds = 0);


    }
}
