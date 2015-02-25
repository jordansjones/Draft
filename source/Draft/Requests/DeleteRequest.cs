using System;

using Flurl.Http;

using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

using Flurl;

namespace Draft.Requests
{
    internal class DeleteRequest : BaseRequest, IDeleteDirectoryRequest, IDeleteKeyRequest
    {

        public DeleteRequest(Url endpointUrl, string path, bool isDirectory)
            : base(endpointUrl, path)
        {
            IsDirectory = isDirectory;
        }

        public bool IsDirectory { get; private set; }

        public bool? Recursive { get; private set; }

        public async Task<object> Execute()
        {
            return await TargetUrl
                .Conditionally(IsDirectory, x => x.SetQueryParam(EtcdConstants.Parameter_Directory, EtcdConstants.Parameter_True))
                .Conditionally(IsDirectory && Recursive.HasValue && Recursive.Value, x => x.SetQueryParam(EtcdConstants.Parameter_Recursive, EtcdConstants.Parameter_True))
                .DeleteAsync(CancellationToken)
                .ReceiveJson();
        }

        public TaskAwaiter<object> GetAwaiter()
        {
            return Execute().GetAwaiter();
        }

        IDeleteDirectoryRequest IDeleteDirectoryRequest.WithCancellationToken(CancellationToken token)
        {
            CancellationToken = token;
            return this;
        }

        public IDeleteDirectoryRequest WithRecursive(bool recursive = true)
        {
            Recursive = recursive;
            return this;
        }

        IDeleteKeyRequest IDeleteKeyRequest.WithCancellationToken(CancellationToken token)
        {
            CancellationToken = token;
            return this;
        }

    }
}
