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

        public static readonly Func<Task<IEtcdVersion>> CallFixture = async () => await Etcd.ClientFor(Fixtures.EtcdUrl.ToUri()).GetVersion();

        public static HttpTest NewErrorCodeFixture(int? etcd = null, HttpStatusCode status = HttpStatusCode.BadRequest)
        {
            return new HttpTest()
                .RespondWithJson(status, Fixtures.CreateErrorMessage(etcd));
        }

        [Fact]
        public void ShouldParseErrorCodeFromHttpStatusIfMissingFromBody()
        {
            using (NewErrorCodeFixture(status : HttpStatusCode.Conflict))
            {
                CallFixture.ShouldThrow<ExistingPeerAddressException>();
            }
        }

        [Fact]
        public void ShouldParseErrorCodeFromMessageBody()
        {
            using (NewErrorCodeFixture(Constants.Etcd.ErrorCode_Unknown))
            {
                CallFixture.ShouldThrow<UnknownErrorException>();
            }
        }

        [Fact]
        public void ShouldThrowEtcdTimeoutException()
        {
            using (var http = new HttpTest())
            {
                http.SimulateTimeout();

                CallFixture.ShouldThrow<EtcdTimeoutException>()
                    .And
                    .IsTimeout.Should().BeTrue();
            }
        }

        [Fact]
        public void ShouldThrowInvalidHostException()
        {
            FlurlHttp.Configure(
                x => { x.HttpClientFactory = new InvalidHostExceptionTestClientFactory(); });

            CallFixture.ShouldThrow<InvalidHostException>()
                .And
                .IsInvalidHost.Should().BeTrue();
        }

        [Fact]
        public void ShouldThrowInvalidRequestException()
        {
            using (var http = new HttpTest())
            {
                http.RespondWith(HttpStatusCode.NotFound, HttpStatusCode.NotFound.ToString());

                CallFixture.ShouldThrow<InvalidRequestException>()
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
                CallFixture.ShouldThrow<ClientInternalException>()
                    .And
                    .IsClientInternal.Should().BeTrue();
            }
        }

        [Fact]
        public void ShouldThrowDirectoryNotEmptyException()
        {
            using (NewErrorCodeFixture(Constants.Etcd.ErrorCode_DirectoryNotEmpty))
            {
                CallFixture.ShouldThrow<DirectoryNotEmptyException>()
                    .And
                    .IsDirectoryNotEmpty.Should().BeTrue();
            }
        }

        [Fact]
        public void ShouldThrowEventIndexClearedException()
        {
            using (NewErrorCodeFixture(Constants.Etcd.ErrorCode_EventIndexCleared))
            {
                CallFixture.ShouldThrow<EventIndexClearedException>()
                    .And
                    .IsEventIndexCleared.Should().BeTrue();
            }
        }

        [Fact]
        public void ShouldThrowExistingPeerAddressException()
        {
            using (NewErrorCodeFixture(Constants.Etcd.ErrorCode_ExistingPeerAddress))
            {
                CallFixture.ShouldThrow<ExistingPeerAddressException>()
                    .And
                    .IsExistingPeerAddress.Should().BeTrue();
            }
        }

        [Fact]
        public void ShouldThrowIndexNotANumberException()
        {
            using (NewErrorCodeFixture(Constants.Etcd.ErrorCode_IndexNotANumber))
            {
                CallFixture.ShouldThrow<IndexNotANumberException>()
                    .And
                    .IsIndexNotANumber.Should().BeTrue();
            }
        }

        [Fact]
        public void ShouldThrowIndexOrValueRequiredException()
        {
            using (NewErrorCodeFixture(Constants.Etcd.ErrorCode_IndexOrValueRequired))
            {
                CallFixture.ShouldThrow<IndexOrValueRequiredException>()
                    .And
                    .IsIndexOrValueRequired.Should().BeTrue();
            }
        }

        [Fact]
        public void ShouldThrowIndexValueMutexException()
        {
            using (NewErrorCodeFixture(Constants.Etcd.ErrorCode_IndexValueMutex))
            {
                CallFixture.ShouldThrow<IndexValueMutexException>()
                    .And
                    .IsIndexValueMutex.Should().BeTrue();
            }
        }

        [Fact]
        public void ShouldThrowInvalidActiveSizeException()
        {
            using (NewErrorCodeFixture(Constants.Etcd.ErrorCode_InvalidActiveSize))
            {
                CallFixture.ShouldThrow<InvalidActiveSizeException>()
                    .And
                    .IsInvalidActiveSize.Should().BeTrue();
            }
        }

        [Fact]
        public void ShouldThrowInvalidFieldException()
        {
            using (NewErrorCodeFixture(Constants.Etcd.ErrorCode_InvalidField))
            {
                CallFixture.ShouldThrow<InvalidFieldException>()
                    .And
                    .IsInvalidField.Should().BeTrue();
            }
        }

        [Fact]
        public void ShouldThrowInvalidFormException()
        {
            using (NewErrorCodeFixture(Constants.Etcd.ErrorCode_InvalidForm))
            {
                CallFixture.ShouldThrow<InvalidFormException>()
                    .And
                    .IsInvalidForm.Should().BeTrue();
            }
        }

        [Fact]
        public void ShouldThrowInvalidRemoveDelayException()
        {
            using (NewErrorCodeFixture(Constants.Etcd.ErrorCode_InvalidRemoveDelay))
            {
                CallFixture.ShouldThrow<InvalidRemoveDelayException>()
                    .And
                    .IsInvalidRemoveDelay.Should().BeTrue();
            }
        }

        [Fact]
        public void ShouldThrowKeyIsPreservedException()
        {
            using (NewErrorCodeFixture(Constants.Etcd.ErrorCode_KeyIsPreserved))
            {
                CallFixture.ShouldThrow<KeyIsPreservedException>()
                    .And
                    .IsKeyIsPreserved.Should().BeTrue();
            }
        }

        [Fact]
        public void ShouldThrowKeyNotFoundException()
        {
            using (NewErrorCodeFixture(Constants.Etcd.ErrorCode_KeyNotFound))
            {
                CallFixture.ShouldThrow<KeyNotFoundException>()
                    .And
                    .IsKeyNotFound.Should().BeTrue();
            }
        }

        [Fact]
        public void ShouldThrowLeaderElectException()
        {
            using (NewErrorCodeFixture(Constants.Etcd.ErrorCode_LeaderElect))
            {
                CallFixture.ShouldThrow<LeaderElectException>()
                    .And
                    .IsLeaderElect.Should().BeTrue();
            }
        }

        [Fact]
        public void ShouldThrowNameRequiredException()
        {
            using (NewErrorCodeFixture(Constants.Etcd.ErrorCode_NameRequired))
            {
                CallFixture.ShouldThrow<NameRequiredException>()
                    .And
                    .IsNameRequired.Should().BeTrue();
            }
        }

        [Fact]
        public void ShouldThrowNodeExistsException()
        {
            using (NewErrorCodeFixture(Constants.Etcd.ErrorCode_NodeExists))
            {
                CallFixture.ShouldThrow<NodeExistsException>()
                    .And
                    .IsNodeExists.Should().BeTrue();
            }
        }

        [Fact]
        public void ShouldThrowNoMorePeerException()
        {
            using (NewErrorCodeFixture(Constants.Etcd.ErrorCode_NoMorePeer))
            {
                CallFixture.ShouldThrow<NoMorePeerException>()
                    .And
                    .IsNoMorePeer.Should().BeTrue();
            }
        }

        [Fact]
        public void ShouldThrowNotADirectoryException()
        {
            using (NewErrorCodeFixture(Constants.Etcd.ErrorCode_NotDirectory))
            {
                CallFixture.ShouldThrow<NotADirectoryException>()
                    .And
                    .IsNotDirectory.Should().BeTrue();
            }
        }

        [Fact]
        public void ShouldThrowNotAFileException()
        {
            using (NewErrorCodeFixture(Constants.Etcd.ErrorCode_NotFile))
            {
                CallFixture.ShouldThrow<NotAFileException>()
                    .And
                    .IsNotFile.Should().BeTrue();
            }
        }

        [Fact]
        public void ShouldThrowPreviousValueRequiredException()
        {
            using (NewErrorCodeFixture(Constants.Etcd.ErrorCode_PreviousValueRequired))
            {
                CallFixture.ShouldThrow<PreviousValueRequiredException>()
                    .And
                    .IsPreviousValueRequired.Should().BeTrue();
            }
        }

        [Fact]
        public void ShouldThrowRaftInternalException()
        {
            using (NewErrorCodeFixture(Constants.Etcd.ErrorCode_RaftInternal))
            {
                CallFixture.ShouldThrow<RaftInternalException>()
                    .And
                    .IsRaftInternal.Should().BeTrue();
            }
        }

        [Fact]
        public void ShouldThrowRootIsReadOnlyException()
        {
            using (NewErrorCodeFixture(Constants.Etcd.ErrorCode_RootReadOnly))
            {
                CallFixture.ShouldThrow<RootIsReadOnlyException>()
                    .And
                    .IsRootReadOnly.Should().BeTrue();
            }
        }

        [Fact]
        public void ShouldThrowStandbyInternalException()
        {
            using (NewErrorCodeFixture(Constants.Etcd.ErrorCode_StandbyInternal))
            {
                CallFixture.ShouldThrow<StandbyInternalException>()
                    .And
                    .IsStandbyInternal.Should().BeTrue();
            }
        }

        [Fact]
        public void ShouldThrowTestFailedException()
        {
            using (NewErrorCodeFixture(Constants.Etcd.ErrorCode_TestFailed))
            {
                CallFixture.ShouldThrow<TestFailedException>()
                    .And
                    .IsTestFailed.Should().BeTrue();
            }
        }

        [Fact]
        public void ShouldThrowTimeoutNotANumberException()
        {
            using (NewErrorCodeFixture(Constants.Etcd.ErrorCode_TimeoutNotANumber))
            {
                CallFixture.ShouldThrow<TimeoutNotANumberException>()
                    .And
                    .IsTimeoutNotANumber.Should().BeTrue();
            }
        }

        [Fact]
        public void ShouldThrowTtlNotANumberException()
        {
            using (NewErrorCodeFixture(Constants.Etcd.ErrorCode_TtlNotANumber))
            {
                CallFixture.ShouldThrow<TtlNotANumberException>()
                    .And
                    .IsTtlNotANumber.Should().BeTrue();
            }
        }

        [Fact]
        public void ShouldThrowUnknownErrorException()
        {
            using (NewErrorCodeFixture(Constants.Etcd.ErrorCode_Unknown))
            {
                CallFixture.ShouldThrow<UnknownErrorException>()
                    .And
                    .IsUnknown.Should().BeTrue();
            }
        }

        [Fact]
        public void ShouldThrowValueOrTtlRequiredException()
        {
            using (NewErrorCodeFixture(Constants.Etcd.ErrorCode_ValueOrTtlRequired))
            {
                CallFixture.ShouldThrow<ValueOrTtlRequiredException>()
                    .And
                    .IsValueOrTtlRequired.Should().BeTrue();
            }
        }

        [Fact]
        public void ShouldThrowValueRequiredException()
        {
            using (NewErrorCodeFixture(Constants.Etcd.ErrorCode_ValueRequired))
            {
                CallFixture.ShouldThrow<ValueRequiredException>()
                    .And
                    .IsValueRequired.Should().BeTrue();
            }
        }

        [Fact]
        public void ShouldThrowWatcherClearedException()
        {
            using (NewErrorCodeFixture(Constants.Etcd.ErrorCode_WatcherCleared))
            {
                CallFixture.ShouldThrow<WatcherClearedException>()
                    .And
                    .IsWatcherCleared.Should().BeTrue();
            }
        }

        #endregion
    }
}
