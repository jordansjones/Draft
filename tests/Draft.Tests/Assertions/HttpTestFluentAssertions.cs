using System;
using System.Collections.Generic;
using System.Linq;

using FluentAssertions.Execution;

using Flurl.Http;

namespace Draft.Tests.Assertions
{
    public class HttpTestFluentAssertions : BaseFluentAssertions
    {

        public HttpTestFluentAssertions(IList<HttpCall> calls) : base(calls) {}

        public HttpCallFluentAssertions HaveCalled(string urlPattern, string because = "", params object[] reasonArgs)
        {
            var matchingCalls = FilterCalls(x => MatchesPattern(x.Request.RequestUri.AbsoluteUri, urlPattern));
            Execute.Assertion
                .ForCondition(matchingCalls.Any())
                .BecauseOf(because, reasonArgs)
                .FailWith("Expected {context:IEtcdClient} to have called {0}{reason}, but did not find any calls.", urlPattern);

            return new HttpCallFluentAssertions(matchingCalls);
        }

        public HttpCallFluentAssertions NotHaveCalled(string urlPattern, string because = "", params object[] reasonArgs)
        {
            var matchingCalls = FilterCalls(x => MatchesPattern(x.Request.RequestUri.AbsoluteUri, urlPattern));
            Execute.Assertion
                .ForCondition(!matchingCalls.Any())
                .BecauseOf(because, reasonArgs)
                .FailWith("Expected {context:IEtcdClient} to not have called {0}{reason}, but found {1} calls.", urlPattern, matchingCalls.Count);

            return new HttpCallFluentAssertions(matchingCalls);
        }

    }
}
