using System;

using FluentAssertions;

using System.Linq;
using System.Net;
using System.Threading.Tasks;

using Draft.Exceptions;
using Draft.Responses;

using Flurl.Http;
using Flurl.Http.Testing;

using Xunit;

namespace Draft.Tests.Exceptions
{
    public class CoreExceptionTests
    {
        private static readonly Func<Task<IEtcdVersion>> CallFixture = async () => await Etcd.ClientFor(Fixtures.EtcdUrl.ToUri()).GetVersion();

        private static HttpTest NewErrorCodeFixture(int? etcdErrorCode = null, HttpStatusCode status = HttpStatusCode.BadRequest)
        {
            return new HttpTest()
                .RespondWithJson(status, Fixtures.CreateErrorMessage(etcdErrorCode));
        }

        [Fact]
        public void ShouldParseErrorCodeFromHttpStatusIfMissingFromBody()
        {
            using (NewErrorCodeFixture(status : HttpStatusCode.Conflict))
            {
                CallFixture.Should().Throw<ExistingPeerAddressException>();
            }
        }

        [Fact]
        public void ShouldParseErrorCodeFromMessageBody()
        {
            using (NewErrorCodeFixture(Constants.Etcd.ErrorCode_Unknown))
            {
                CallFixture.Should().Throw<UnknownErrorException>();
            }
        }

        [Fact]
        public void ShouldThrowEtcdTimeoutException()
        {
            using (var http = new HttpTest())
            {
                http.SimulateTimeout();

                CallFixture.Should().Throw<EtcdTimeoutException>()
                    .And
                    .IsTimeout.Should().BeTrue();
            }
        }

        [Fact]
        public void ShouldThrowInvalidHostException()
        {
            using (new HttpTest().Configure(x =>
            {
                x.HttpClientFactory = new TestingHttpClientFactory();
            }))
            {
                CallFixture.Should().Throw<InvalidHostException>()
                    .And
                    .IsInvalidHost.Should().BeTrue();
            }
        }

        [Fact]
        public void ShouldThrowInvalidRequestException()
        {
            using (var http = new HttpTest())
            {
                http.RespondWith(HttpStatusCode.NotFound, HttpStatusCode.NotFound.ToString());

                CallFixture.Should().Throw<InvalidRequestException>()
                    .And
                    .IsInvalidRequest.Should().BeTrue();
            }
        }

        #region Exception Type Tests

        [Fact]
        public void ShouldThrowClientInternalException()
        {
            using (NewErrorCodeFixture(Constants.Etcd.ErrorCode_ClientInternal))
            {
                CallFixture.Should().Throw<ClientInternalException>()
                    .And
                    .IsClientInternal.Should().BeTrue();
            }
        }

        [Fact]
        public void ShouldThrowDirectoryNotEmptyException()
        {
            using (NewErrorCodeFixture(Constants.Etcd.ErrorCode_DirectoryNotEmpty))
            {
                CallFixture.Should().Throw<DirectoryNotEmptyException>()
                    .And
                    .IsDirectoryNotEmpty.Should().BeTrue();
            }
        }

        [Fact]
        public void ShouldThrowEventIndexClearedException()
        {
            using (NewErrorCodeFixture(Constants.Etcd.ErrorCode_EventIndexCleared))
            {
                CallFixture.Should().Throw<EventIndexClearedException>()
                    .And
                    .IsEventIndexCleared.Should().BeTrue();
            }
        }

        [Fact]
        public void ShouldThrowExistingPeerAddressException()
        {
            using (NewErrorCodeFixture(Constants.Etcd.ErrorCode_ExistingPeerAddress))
            {
                CallFixture.Should().Throw<ExistingPeerAddressException>()
                    .And
                    .IsExistingPeerAddress.Should().BeTrue();
            }
        }

        [Fact]
        public void ShouldThrowHttpConnectionException()
        {
            using (new HttpTest().Configure(x =>
            {
                x.HttpClientFactory = new TestingHttpClientFactory( /*new HttpTest(), */(ht, hrm) => { throw new WebException("The Message", WebExceptionStatus.ConnectFailure); });
            }))
            {

                CallFixture.Should().Throw<HttpConnectionException>()
                    .And
                    .IsHttpConnection.Should().BeTrue();
            }
        }

        [Fact]
        public void ShouldThrowIndexNotANumberException()
        {
            using (NewErrorCodeFixture(Constants.Etcd.ErrorCode_IndexNotANumber))
            {
                CallFixture.Should().Throw<IndexNotANumberException>()
                    .And
                    .IsIndexNotANumber.Should().BeTrue();
            }
        }

        [Fact]
        public void ShouldThrowIndexOrValueRequiredException()
        {
            using (NewErrorCodeFixture(Constants.Etcd.ErrorCode_IndexOrValueRequired))
            {
                CallFixture.Should().Throw<IndexOrValueRequiredException>()
                    .And
                    .IsIndexOrValueRequired.Should().BeTrue();
            }
        }

        [Fact]
        public void ShouldThrowIndexValueMutexException()
        {
            using (NewErrorCodeFixture(Constants.Etcd.ErrorCode_IndexValueMutex))
            {
                CallFixture.Should().Throw<IndexValueMutexException>()
                    .And
                    .IsIndexValueMutex.Should().BeTrue();
            }
        }

        [Fact]
        public void ShouldThrowInvalidActiveSizeException()
        {
            using (NewErrorCodeFixture(Constants.Etcd.ErrorCode_InvalidActiveSize))
            {
                CallFixture.Should().Throw<InvalidActiveSizeException>()
                    .And
                    .IsInvalidActiveSize.Should().BeTrue();
            }
        }

        [Fact]
        public void ShouldThrowInvalidFieldException()
        {
            using (NewErrorCodeFixture(Constants.Etcd.ErrorCode_InvalidField))
            {
                CallFixture.Should().Throw<InvalidFieldException>()
                    .And
                    .IsInvalidField.Should().BeTrue();
            }
        }

        [Fact]
        public void ShouldThrowInvalidFormException()
        {
            using (NewErrorCodeFixture(Constants.Etcd.ErrorCode_InvalidForm))
            {
                CallFixture.Should().Throw<InvalidFormException>()
                    .And
                    .IsInvalidForm.Should().BeTrue();
            }
        }

        [Fact]
        public void ShouldThrowInvalidRemoveDelayException()
        {
            using (NewErrorCodeFixture(Constants.Etcd.ErrorCode_InvalidRemoveDelay))
            {
                CallFixture.Should().Throw<InvalidRemoveDelayException>()
                    .And
                    .IsInvalidRemoveDelay.Should().BeTrue();
            }
        }

        [Fact]
        public void ShouldThrowKeyIsPreservedException()
        {
            using (NewErrorCodeFixture(Constants.Etcd.ErrorCode_KeyIsPreserved))
            {
                CallFixture.Should().Throw<KeyIsPreservedException>()
                    .And
                    .IsKeyIsPreserved.Should().BeTrue();
            }
        }

        [Fact]
        public void ShouldThrowKeyNotFoundException()
        {
            using (NewErrorCodeFixture(Constants.Etcd.ErrorCode_KeyNotFound))
            {
                CallFixture.Should().Throw<KeyNotFoundException>()
                    .And
                    .IsKeyNotFound.Should().BeTrue();
            }
        }

        [Fact]
        public void ShouldThrowLeaderElectException()
        {
            using (NewErrorCodeFixture(Constants.Etcd.ErrorCode_LeaderElect))
            {
                CallFixture.Should().Throw<LeaderElectException>()
                    .And
                    .IsLeaderElect.Should().BeTrue();
            }
        }

        [Fact]
        public void ShouldThrowNameRequiredException()
        {
            using (NewErrorCodeFixture(Constants.Etcd.ErrorCode_NameRequired))
            {
                CallFixture.Should().Throw<NameRequiredException>()
                    .And
                    .IsNameRequired.Should().BeTrue();
            }
        }

        [Fact]
        public void ShouldThrowNodeExistsException()
        {
            using (NewErrorCodeFixture(Constants.Etcd.ErrorCode_NodeExists))
            {
                CallFixture.Should().Throw<NodeExistsException>()
                    .And
                    .IsNodeExists.Should().BeTrue();
            }
        }

        [Fact]
        public void ShouldThrowNoMorePeerException()
        {
            using (NewErrorCodeFixture(Constants.Etcd.ErrorCode_NoMorePeer))
            {
                CallFixture.Should().Throw<NoMorePeerException>()
                    .And
                    .IsNoMorePeer.Should().BeTrue();
            }
        }

        [Fact]
        public void ShouldThrowNotADirectoryException()
        {
            using (NewErrorCodeFixture(Constants.Etcd.ErrorCode_NotDirectory))
            {
                CallFixture.Should().Throw<NotADirectoryException>()
                    .And
                    .IsNotDirectory.Should().BeTrue();
            }
        }

        [Fact]
        public void ShouldThrowNotAFileException()
        {
            using (NewErrorCodeFixture(Constants.Etcd.ErrorCode_NotFile))
            {
                CallFixture.Should().Throw<NotAFileException>()
                    .And
                    .IsNotFile.Should().BeTrue();
            }
        }

        [Fact]
        public void ShouldThrowPreviousValueRequiredException()
        {
            using (NewErrorCodeFixture(Constants.Etcd.ErrorCode_PreviousValueRequired))
            {
                CallFixture.Should().Throw<PreviousValueRequiredException>()
                    .And
                    .IsPreviousValueRequired.Should().BeTrue();
            }
        }

        [Fact]
        public void ShouldThrowRaftInternalException()
        {
            using (NewErrorCodeFixture(Constants.Etcd.ErrorCode_RaftInternal))
            {
                CallFixture.Should().Throw<RaftInternalException>()
                    .And
                    .IsRaftInternal.Should().BeTrue();
            }
        }

        [Fact]
        public void ShouldThrowRootIsReadOnlyException()
        {
            using (NewErrorCodeFixture(Constants.Etcd.ErrorCode_RootReadOnly))
            {
                CallFixture.Should().Throw<RootIsReadOnlyException>()
                    .And
                    .IsRootReadOnly.Should().BeTrue();
            }
        }

        [Fact]
        public void ShouldThrowStandbyInternalException()
        {
            using (NewErrorCodeFixture(Constants.Etcd.ErrorCode_StandbyInternal))
            {
                CallFixture.Should().Throw<StandbyInternalException>()
                    .And
                    .IsStandbyInternal.Should().BeTrue();
            }
        }

        [Fact]
        public void ShouldThrowTestFailedException()
        {
            using (NewErrorCodeFixture(Constants.Etcd.ErrorCode_TestFailed))
            {
                CallFixture.Should().Throw<TestFailedException>()
                    .And
                    .IsTestFailed.Should().BeTrue();
            }
        }

        [Fact]
        public void ShouldThrowTimeoutNotANumberException()
        {
            using (NewErrorCodeFixture(Constants.Etcd.ErrorCode_TimeoutNotANumber))
            {
                CallFixture.Should().Throw<TimeoutNotANumberException>()
                    .And
                    .IsTimeoutNotANumber.Should().BeTrue();
            }
        }

        [Fact]
        public void ShouldThrowTtlNotANumberException()
        {
            using (NewErrorCodeFixture(Constants.Etcd.ErrorCode_TtlNotANumber))
            {
                CallFixture.Should().Throw<TtlNotANumberException>()
                    .And
                    .IsTtlNotANumber.Should().BeTrue();
            }
        }

        [Fact]
        public void ShouldThrowUnknownErrorException()
        {
            using (NewErrorCodeFixture(Constants.Etcd.ErrorCode_Unknown))
            {
                CallFixture.Should().Throw<UnknownErrorException>()
                    .And
                    .IsUnknown.Should().BeTrue();
            }
        }

        [Fact]
        public void ShouldThrowValueOrTtlRequiredException()
        {
            using (NewErrorCodeFixture(Constants.Etcd.ErrorCode_ValueOrTtlRequired))
            {
                CallFixture.Should().Throw<ValueOrTtlRequiredException>()
                    .And
                    .IsValueOrTtlRequired.Should().BeTrue();
            }
        }

        [Fact]
        public void ShouldThrowValueRequiredException()
        {
            using (NewErrorCodeFixture(Constants.Etcd.ErrorCode_ValueRequired))
            {
                CallFixture.Should().Throw<ValueRequiredException>()
                    .And
                    .IsValueRequired.Should().BeTrue();
            }
        }

        [Fact]
        public void ShouldThrowWatcherClearedException()
        {
            using (NewErrorCodeFixture(Constants.Etcd.ErrorCode_WatcherCleared))
            {
                CallFixture.Should().Throw<WatcherClearedException>()
                    .And
                    .IsWatcherCleared.Should().BeTrue();
            }
        }

        #endregion
    }
}
