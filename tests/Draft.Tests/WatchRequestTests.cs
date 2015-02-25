using System;

using FluentAssertions;

using Flurl;

using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

using Flurl.Http.Testing;

using Xunit;

namespace Draft.Tests
{
    public class WatchRequestTests
    {

        [Fact]
        public void Watch_ShouldRetryOnTimeoutException()
        {
            using (var http = new HttpTest())
            {
                http.SimulateTimeout()
                    .SimulateTimeout()
                    .SimulateTimeout()
                    .RespondWithJson(Fixtures.Watch.DefaultResponse);

                Etcd.ClientFor(Fixtures.EtcdUrl.ToUri())
                    .Watch(Fixtures.Watch.Path)
                    .SubscribeFor(1)
                    .Wait();

                http.Should()
                    .HaveCalled(
                        Fixtures.EtcdUrl
                            .AppendPathSegment(EtcdConstants.Path_Keys)
                            .AppendPathSegment(Fixtures.Watch.Path)
                            .SetQueryParam(EtcdConstants.Parameter_Wait, EtcdConstants.Parameter_True)
                    )
                    .WithVerb(HttpMethod.Get)
                    .Times(4);
            }
        }

        [Fact]
        public async Task Watch_ShouldStopPollingOnA500LevelResponse()
        {
            using (var http = new HttpTest())
            {
                http.RespondWith(500, "Some error string")
                    .RespondWithJson(Fixtures.Watch.DefaultResponse)
                    .RespondWithJson(Fixtures.Watch.DefaultResponse);

                var tcs = new TaskCompletionSource<object>();
                var task = tcs.Task;

                Etcd.ClientFor(Fixtures.EtcdUrl.ToUri())
                    .Watch(Fixtures.Watch.Path)
                    .Subscribe(tcs.SetResult, x => tcs.SetException(x));

                try
                {
                    await task;
                }
                catch
                {
                    // ignored
                }

                http.Should()
                    .HaveCalled(
                        Fixtures.EtcdUrl
                            .AppendPathSegment(EtcdConstants.Path_Keys)
                            .AppendPathSegment(Fixtures.Watch.Path)
                            .SetQueryParam(EtcdConstants.Parameter_Wait, EtcdConstants.Parameter_True)
                    )
                    .WithVerb(HttpMethod.Get)
                    .Times(1);

                task.IsCompleted.Should().BeTrue();
                task.IsFaulted.Should().BeTrue();
            }
        }

        [Fact]
        public void Watch_ShouldStopPollingWhenSubscriptionIsDisposed()
        {
            using (var http = new HttpTest())
            {
                http.RespondWithJson(Fixtures.Watch.DefaultResponse)
                    .RespondWithJson(Fixtures.Watch.DefaultResponse)
                    .RespondWithJson(Fixtures.Watch.DefaultResponse)
                    .RespondWithJson(Fixtures.Watch.DefaultResponse)
                    .RespondWithJson(Fixtures.Watch.DefaultResponse);

                Etcd.ClientFor(Fixtures.EtcdUrl.ToUri())
                    .Watch(Fixtures.Watch.Path)
                    .SubscribeFor(3)
                    .Wait();

                http.Should()
                    .HaveCalled(
                        Fixtures.EtcdUrl
                            .AppendPathSegment(EtcdConstants.Path_Keys)
                            .AppendPathSegment(Fixtures.Watch.Path)
                            .SetQueryParam(EtcdConstants.Parameter_Wait, EtcdConstants.Parameter_True)
                    )
                    .WithVerb(HttpMethod.Get);

                http.CallLog.Should()
                    .HaveCount(3);
            }
        }

        [Fact]
        public void WatchOnce_ShouldOnlyBeNotifiedOnce()
        {
            using (var http = new HttpTest())
            {
                http.RespondWithJson(Fixtures.Watch.DefaultResponse)
                    .RespondWithJson(Fixtures.Watch.DefaultResponse);

                var tcs = new TaskCompletionSource<object>();

                Etcd.ClientFor(Fixtures.EtcdUrl.ToUri())
                    .WatchOnce(Fixtures.Watch.Path)
                    .Subscribe(tcs.SetResult, tcs.SetException);

                tcs.Task.Wait();

                http.Should()
                    .HaveCalled(
                        Fixtures.EtcdUrl
                            .AppendPathSegment(EtcdConstants.Path_Keys)
                            .AppendPathSegment(Fixtures.Watch.Path)
                            .SetQueryParam(EtcdConstants.Parameter_Wait, EtcdConstants.Parameter_True)
                    )
                    .WithVerb(HttpMethod.Get)
                    .Times(1);

                http.CallLog.Should()
                    .HaveCount(1);

                tcs.Task.IsCompleted.Should().BeTrue();
                tcs.Task.Result.Should().NotBeNull();
            }
        }

        [Fact]
        public void WatchOnce_ShouldCallTheCorrectUrlWithRecursiveOption()
        {
            using (var http = new HttpTest())
            {
                Etcd.ClientFor(Fixtures.EtcdUrl.ToUri())
                    .WatchOnce(Fixtures.Watch.Path)
                    .WithRecursive(true)
                    .SubscribeFor(1);

                http.Should()
                    .HaveCalled(
                        Fixtures.EtcdUrl
                            .AppendPathSegment(EtcdConstants.Path_Keys)
                            .AppendPathSegment(Fixtures.Watch.Path)
                            .SetQueryParam(EtcdConstants.Parameter_Wait, EtcdConstants.Parameter_True)
                            .SetQueryParam(EtcdConstants.Parameter_Recursive, EtcdConstants.Parameter_True)
                    )
                    .WithVerb(HttpMethod.Get)
                    .Times(1);
            }
        }

        [Fact]
        public void WatchOnce_ShouldCallTheCurrectUrlWithModifiedIndexOption()
        {
            const int modifiedIndex = 3;
            using (var http = new HttpTest())
            {
                Etcd.ClientFor(Fixtures.EtcdUrl.ToUri())
                    .WatchOnce(Fixtures.Watch.Path)
                    .WithModifiedIndex(modifiedIndex)
                    .SubscribeFor(1);

                http.Should()
                    .HaveCalled(
                        Fixtures.EtcdUrl
                            .AppendPathSegment(EtcdConstants.Path_Keys)
                            .AppendPathSegment(Fixtures.Watch.Path)
                            .SetQueryParam(EtcdConstants.Parameter_Wait, EtcdConstants.Parameter_True)
                            .SetQueryParam(EtcdConstants.Parameter_WaitIndex, modifiedIndex)
                    )
                    .WithVerb(HttpMethod.Get)
                    .Times(1);
            }
        }

    }
}
