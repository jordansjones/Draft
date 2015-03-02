using System;

using Flurl.Http;

using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

using Draft.Responses;

using Flurl;

namespace Draft.Requests
{
    internal class DeleteRequest : BaseRequest, IDeleteDirectoryRequest, IDeleteKeyRequest
    {

        public DeleteRequest(IEtcdClient client, Url endpointUrl, string path, bool isDirectory)
            : base(client, endpointUrl, path)
        {
            IsDirectory = isDirectory;
        }

        public bool IsDirectory { get; private set; }

        public bool? Recursive { get; private set; }

        public async Task<IKeyEvent> Execute()
        {
            return await TargetUrl
                .Conditionally(IsDirectory, x => x.SetQueryParam(EtcdConstants.Parameter_Directory, EtcdConstants.Parameter_True))
                .Conditionally(IsDirectory && Recursive.HasValue && Recursive.Value, x => x.SetQueryParam(EtcdConstants.Parameter_Recursive, EtcdConstants.Parameter_True))
                .DeleteAsync()
                .ReceiveEtcdResponse<KeyEvent>();
        }

        public TaskAwaiter<IKeyEvent> GetAwaiter()
        {
            return Execute().GetAwaiter();
        }

        public IDeleteDirectoryRequest WithRecursive(bool recursive = true)
        {
            Recursive = recursive;
            return this;
        }

    }
}
