using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Draft.Requests
{
    public interface IDeleteKeyRequest
    {

        Task<object> Execute();

        TaskAwaiter<object> GetAwaiter();

    }
}
