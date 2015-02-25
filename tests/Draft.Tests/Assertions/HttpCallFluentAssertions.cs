using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.Http;

using FluentAssertions.Execution;

using Flurl.Http;

namespace Draft.Tests.Assertions
{
    [ExcludeFromCodeCoverage]
    public class HttpCallFluentAssertions : BaseFluentAssertions
    {

        public HttpCallFluentAssertions(IList<HttpCall> calls) : base(calls) {}

        public void Times(int expectedCount, string because = "", params object[] reasonArgs)
        {
            Execute.Assertion
                .ForCondition(Calls.Count == expectedCount)
                .BecauseOf(because, reasonArgs)
                .FailWith("Expected {context:IEtcdClient to have made {0} call(s){reason}, but found {1}", expectedCount, Calls.Count);
        }

        public HttpCallFluentAssertions WithContentType(string contentType, string because = "", params object[] reasonArgs)
        {
            var matchingCalls = FilterCalls(x => x.Request.Content.Headers.ContentType.MediaType.Equals(contentType, StringComparison.InvariantCultureIgnoreCase));
            Execute.Assertion
                .ForCondition(matchingCalls.Any())
                .BecauseOf(because, reasonArgs)
                .FailWith("Expected {context:IEtcdClient to have called {0} with a content type of {1}{reason}, but did not find any calls.", FirstRequestAbsoluteUri, contentType);

            return new HttpCallFluentAssertions(matchingCalls);
        }

        public HttpCallFluentAssertions WithRequestBody(string bodyPattern, string because = "", params object[] reasonArgs)
        {
            var matchingCalls = FilterCalls(x => MatchesPattern(x.RequestBody, bodyPattern));
            Execute.Assertion
                .ForCondition(matchingCalls.Any())
                .BecauseOf(because, reasonArgs)
                .FailWith("Expected {context:IEtcdClient to have called {0} with a request body of {1}{reason}, but did not find any calls.", FirstRequestAbsoluteUri, bodyPattern);

            return new HttpCallFluentAssertions(matchingCalls);
        }

        public HttpCallFluentAssertions WithVerb(HttpMethod httpMethod, string because = "", params object[] reasonArgs)
        {
            var matchingCalls = FilterCalls(x => x.Request.Method == httpMethod);
            Execute.Assertion
                .ForCondition(matchingCalls.Any())
                .BecauseOf(because, reasonArgs)
                .FailWith("Expected {context:IEtcdClient} to have called {0} {1}{reason}, but did not find any calls.", httpMethod.Method, FirstRequestAbsoluteUri);

            return new HttpCallFluentAssertions(matchingCalls);
        }

    }
}
