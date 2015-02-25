using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Draft.Requests
{
    public interface ICompareAndDeleteRequest
    {

        ICompareAndDeleteByIndexRequest WithExpectedIndex(long modifiedIndex);

        ICompareAndDeleteByValueRequest WithExpectedValue(string value);

    }

    public interface ICompareAndDeleteByIndexRequest
    {

        Task<object> Execute();

        TaskAwaiter<object> GetAwaiter();

        ICompareAndDeleteByIndexRequest WithCancellationToken(CancellationToken token);

    }

    public interface ICompareAndDeleteByValueRequest
    {

        Task<object> Execute();

        TaskAwaiter<object> GetAwaiter();

        ICompareAndDeleteByValueRequest WithCancellationToken(CancellationToken token);

    }
}
