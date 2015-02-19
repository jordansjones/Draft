using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Draft.Requests
{
    public interface IGetRequest
    {

        Task<object> Execute();

        TaskAwaiter<object> GetAwaiter();

        IGetRequest WithQuorum(bool quorum = true);

        IGetRequest WithRecursive(bool recursive = true);

    }
}
