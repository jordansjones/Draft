using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Draft.Requests
{
    public interface ICompareAndDeleteRequest
    {

        ICompareAndDeleteByIndexRequest WithModifiedIndexOf(long modifiedIndex);

        ICompareAndDeleteByValueRequest WithValueOf(string value);

    }

    public interface ICompareAndDeleteByIndexRequest
    {

        Task<object> Execute();

        TaskAwaiter<object> GetAwaiter();

    }

    public interface ICompareAndDeleteByValueRequest
    {

        Task<object> Execute();

        TaskAwaiter<object> GetAwaiter();

    }
}
