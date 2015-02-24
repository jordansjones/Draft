using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Threading.Tasks;

using FluentAssertions;

using Flurl;
using Flurl.Http;
using Flurl.Http.Testing;

using Xunit;

namespace Draft.Tests
{
    public class WatchTests
    {

        private static readonly object FakeResponseMessage = new
        {
            Message = "Foo"
        };

        [Fact]
        public async Task WatchWillRetryOnTimeoutException()
        {
            const int count = 4;
            using (var http = new HttpTest())
            {
                for (var i = 0; i < count - 1; i++)
                    http.SimulateTimeout();
                
                http
                    .RespondWithJson(FakeResponseMessage);

                var tcs = new TaskCompletionSource<object>();

                Etcd.ClientFor(Fixtures.EtcdUrl.ToUri())
                    .Watch(Fixtures.WatchPath)
                    .Subscribe(tcs.SetResult, tcs.SetException, () => tcs.TrySetResult(null));

                await tcs.Task;

                http.ShouldHaveCalled(Fixtures.EtcdUrl.AppendPathSegment(EtcdConstants.Path_Keys).AppendPathSegment(Fixtures.WatchPath).ToString())
                    .WithVerb(HttpMethod.Get)
                    .Times(count);

                tcs.Task.IsCanceled.Should().BeFalse("because the request wasn't cancelled");
                tcs.Task.IsFaulted.Should().BeFalse(@"because no ""unhandled"" exception was thrown");
            }
        }

        [Fact]
        public async Task WatchWillReturnExceptionOn404()
        {
            using (var http = new HttpTest())
            {
                http.RespondWithJson(404, "404");

                var tcs = new TaskCompletionSource<object>();

                Etcd.ClientFor(Fixtures.EtcdUrl.ToUri())
                    .Watch(Fixtures.WatchPath)
                    .Subscribe(tcs.SetResult, tcs.SetException, () => tcs.TrySetResult(null));

                try
                {
                    await tcs.Task;
                }
                catch (Exception)
                {
                    // ignored
                }

                http.ShouldHaveCalled(Fixtures.EtcdUrl.AppendPathSegment(EtcdConstants.Path_Keys).AppendPathSegments(Fixtures.WatchPath).ToString())
                    .WithVerb(HttpMethod.Get)
                    .Times(1);

                tcs.Task.IsCanceled.Should().BeFalse("because the request wasn't cancelled");
                tcs.Task.IsFaulted.Should().BeTrue(@"because there was an ""unhandled"" exception thrown");
                tcs.Task.Exception.Should().BeOfType<FlurlHttpException>()
                    .Which
                    .Call.Response
                    .StatusCode.Should().Be(HttpStatusCode.NotFound, "because that is the expected outcome");

            }
        }

        [Fact]
        public async Task WatchWillCancelWhenSubscriptionIsDisposed()
        {
            const int count = short.MaxValue;
            using (var http = new HttpTest())
            {
                for (var i = 0; i < count - 1; i++)
                    http.RespondWithJson(FakeResponseMessage);

                var tcs = new TaskCompletionSource<object>();

                var sub = Etcd.ClientFor(Fixtures.EtcdUrl.ToUri())
                    .Watch(Fixtures.WatchPath)
                    .Subscribe(_ => { }, x => tcs.SetException(x), () => tcs.TrySetResult(null));

                await Task.Delay(TimeSpan.FromMilliseconds(10));

                sub.Dispose();

                http.ShouldHaveCalled(Fixtures.EtcdUrl.AppendPathSegment(EtcdConstants.Path_Keys).AppendPathSegments(Fixtures.WatchPath).ToString())
                    .WithVerb(HttpMethod.Get);

                http.CallLog.Count.Should()
                    .BeGreaterThan(0)
                    .And
                    .BeLessThan(count);

                tcs.Task.IsCompleted.Should().BeTrue("because the request was cancelled");
                tcs.Task.IsFaulted.Should().BeFalse(@"because no ""unhandled"" exception was thrown");
            }
        }

    }
}
