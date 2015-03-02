using System;

using Flurl.Http;

using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

using Draft.Responses;

using Flurl;

namespace Draft.Requests
{
    internal class GetRequest : BaseRequest, IGetRequest
    {

        public GetRequest(IEtcdClient client, Url endpointUrl, string path)
            : base(client, endpointUrl, path) {}

        public bool? Quorum { get; private set; }

        public bool? Recursive { get; private set; }

        public async Task<IKeyEvent> Execute()
        {
            return await TargetUrl
                .Conditionally(Quorum.HasValue && Quorum.Value, x => x.SetQueryParam(EtcdConstants.Parameter_Quorum, EtcdConstants.Parameter_True))
                .Conditionally(Recursive.HasValue && Recursive.Value, x => x.SetQueryParam(EtcdConstants.Parameter_Recursive, EtcdConstants.Parameter_True))
                .GetAsync()
                .ReceiveEtcdResponse<KeyEvent>();
        }

        public TaskAwaiter<IKeyEvent> GetAwaiter()
        {
            return Execute().GetAwaiter();
        }

        public IGetRequest WithQuorum(bool quorum = true)
        {
            Quorum = quorum;
            return this;
        }

        public IGetRequest WithRecursive(bool recursive = true)
        {
            Recursive = recursive;
            return this;
        }

    }
}
