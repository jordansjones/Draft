using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Draft.Requests
{
    public interface ICompareAndSwapRequest
    {

        ICompareAndSwapByIndexRequest WithModifiedIndexOf(long modifiedIndex);

        ICompareAndSwapByValueRequest WithValueOf(string value);

    }

    public interface ICompareAndSwapByIndexRequest
    {

        Task<object> Execute();

        TaskAwaiter<object> GetAwaiter();

        ICompareAndSwapByIndexRequest WithNewValue(string value);

        ICompareAndSwapByIndexRequest WithTimeToLive(long? seconds = 0);

    }

    public interface ICompareAndSwapByValueRequest
    {

        Task<object> Execute();

        TaskAwaiter<object> GetAwaiter();

        ICompareAndSwapByValueRequest WithNewValue(string value);

        ICompareAndSwapByValueRequest WithTimeToLive(long? seconds = 0);

    }
}
