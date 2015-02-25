using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

using Flurl;

namespace Draft.Requests
{
    internal class GetRequest : IGetRequest
    {

        public GetRequest(Url endpointUrl, string path)
        {
            EndpointUrl = endpointUrl;
            Path = path;
        }

        public CancellationToken? CancellationToken { get; private set; }

        public Url EndpointUrl { get; private set; }

        public string Path { get; private set; }

        public bool? Quorum { get; private set; }

        public bool? Recursive { get; private set; }

        public async Task<object> Execute()
        {
            return await EndpointUrl
                .AppendPathSegment(Path)
                .Conditionally(Quorum.HasValue && Quorum.Value, x => x.SetQueryParam(EtcdConstants.Parameter_Quorum, EtcdConstants.Parameter_True))
                .Conditionally(Recursive.HasValue && Recursive.Value, x => x.SetQueryParam(EtcdConstants.Parameter_Recursive, EtcdConstants.Parameter_True))
                .GetStringAsync(CancellationToken);
        }

        public TaskAwaiter<object> GetAwaiter()
        {
            return Execute().GetAwaiter();
        }

        public IGetRequest WithCancellationToken(CancellationToken token)
        {
            CancellationToken = token;
            return this;
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
