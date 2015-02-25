using System;

using Flurl.Http;

using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

using Flurl;

namespace Draft.Requests
{
    internal class DeleteRequest : IDeleteDirectoryRequest, IDeleteKeyRequest
    {

        public DeleteRequest(Url endpointUrl, string path, bool isDirectory)
        {
            EndpointUrl = endpointUrl;
            Path = path;
            IsDirectory = isDirectory;
        }

        public CancellationToken? CancellationToken { get; private set; }

        public Url EndpointUrl { get; private set; }

        public bool IsDirectory { get; private set; }

        public string Path { get; private set; }

        public async Task<object> Execute()
        {
            return await EndpointUrl
                .AppendPathSegment(Path)
                .Conditionally(IsDirectory, x => x.SetQueryParam(EtcdConstants.Parameter_Directory, EtcdConstants.Parameter_True))
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

        IDeleteKeyRequest IDeleteKeyRequest.WithCancellationToken(CancellationToken token)
        {
            CancellationToken = token;
            return this;
        }

    }
}
