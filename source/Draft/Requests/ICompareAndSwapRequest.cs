using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Draft.Requests
{
    public interface ICompareAndSwapRequest
    {

        ICompareAndSwapByIndexRequest WithExpectedIndex(long modifiedIndex);

        ICompareAndSwapByValueRequest WithExpectedValue(string value);

    }

    public interface ICompareAndSwapByIndexRequest
    {

        Task<object> Execute();

        TaskAwaiter<object> GetAwaiter();

        ICompareAndSwapByIndexRequest WithCancellationToken(CancellationToken token);

        ICompareAndSwapByIndexRequest WithNewValue(string value);

        ICompareAndSwapByIndexRequest WithTimeToLive(long? seconds = 0);

    }

    public interface ICompareAndSwapByValueRequest
    {

        Task<object> Execute();

        TaskAwaiter<object> GetAwaiter();

        ICompareAndSwapByValueRequest WithCancellationToken(CancellationToken token);

        ICompareAndSwapByValueRequest WithNewValue(string value);

        ICompareAndSwapByValueRequest WithTimeToLive(long? seconds = 0);

    }
}
