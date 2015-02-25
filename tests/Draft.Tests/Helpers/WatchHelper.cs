using System;
using System.Linq;
using System.Threading;

namespace Draft.Tests
{
    public class WatchHelper<T>
    {

        public WatchHelper(IObservable<T> observable, int count)
        {
            CountdownEvent = new CountdownEvent(count);
            Disposable = observable
                .Subscribe(OnNext);
        }

        public CountdownEvent CountdownEvent { get; private set; }

        public IDisposable Disposable { get; private set; }

        private void OnNext(T ignored)
        {
            CountdownEvent.Signal();
            if (CountdownEvent.IsSet)
            {
                Disposable.Dispose();
            }
        }

        public void Wait()
        {
            CountdownEvent.Wait();
        }

    }

    public static class WatchHelperExtensions
    {

        public static WatchHelper<T> SubscribeFor<T>(this IObservable<T> This, int callCount)
        {
            return new WatchHelper<T>(This, callCount);
        }

    }
}
