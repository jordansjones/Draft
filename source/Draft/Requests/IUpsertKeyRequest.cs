using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Draft.Requests
{
    public interface IUpsertKeyRequest
    {

        Task<object> Execute();

        TaskAwaiter<object> GetAwaiter();

        IUpsertKeyRequest WithCancellationToken(CancellationToken token);

        IUpsertKeyRequest WithExisting(bool existing = true);

        IUpsertKeyRequest WithTimeToLive(long? seconds = 0);

        IUpsertKeyRequest WithValue(string value);

    }
}
