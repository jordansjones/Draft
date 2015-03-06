using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

using Draft.Exceptions;
using Draft.Responses;

using FluentAssertions;

using Flurl.Http.Testing;

using Xunit;

namespace Draft.Tests.Exceptions
{
    public class CoreExceptionTests
    {

        public static readonly Func<Task<IEtcdVersion>> CallFixture = async () => await Etcd.ClientFor(Fixtures.EtcdUrl.ToUri()).GetVersion();

        public static HttpTest NewErrorCodeFixture(EtcdErrorCode? etcd = null, HttpStatusCode status = HttpStatusCode.BadRequest)
        {
            return new HttpTest()
                .RespondWithJson(status, Fixtures.CreateErrorMessage(etcd));
        }

        [Fact]
        public void ShouldParseErrorCodeFromMessageBody()
        {
            using (NewErrorCodeFixture(etcd: EtcdErrorCode.Unknown))
            {
                CallFixture.ShouldThrow<UnknownErrorException>();
            }
        }

        [Fact]
        public void ShouldParseErrorCodeFromHttpStatusIfMissingFromBody()
        {
            using (NewErrorCodeFixture(status : HttpStatusCode.Conflict))
            {
                CallFixture.ShouldThrow<ExistingPeerAddressException>();
            }
        }

    }
}
