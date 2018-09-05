using System;

using Flurl.Http;

using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

using Draft.Endpoints;
using Draft.Responses;

namespace Draft.Requests
{
    internal class DeleteRequest : BaseRequest, IDeleteDirectoryRequest, IDeleteKeyRequest
    {

        public DeleteRequest(IEtcdClient etcdClient, EndpointPool endpointPool, bool isDirectory, params string[] pathParts)
            : base(etcdClient, endpointPool, pathParts)
        {
            IsDirectory = isDirectory;
        }

        public bool IsDirectory { get; private set; }

        public bool? Recursive { get; private set; }

        public async Task<IKeyEvent> Execute()
        {
            try
            {
                return await TargetUrl
                    .Conditionally(IsDirectory, x => x.SetQueryParam(Constants.Etcd.Parameter_Directory, Constants.Etcd.Parameter_True))
                    .Conditionally(IsDirectory && Recursive.HasValue && Recursive.Value, x => x.SetQueryParam(Constants.Etcd.Parameter_Recursive, Constants.Etcd.Parameter_True))
                    .DeleteAsync()
                    .ReceiveEtcdResponse<KeyEvent>(EtcdClient);
            }
            catch (FlurlHttpException e)
            {
                throw await e.ProcessException();
            }
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
