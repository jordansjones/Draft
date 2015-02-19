using System;
using System.Linq;
using System.Reactive;

namespace Draft.Requests
{
    public class WatchRequest : ObservableBase<object>, IWatchRequest
    {

        public int? ModifiedIndex { get; private set; }

        public bool? Recursive { get; private set; }

        public IWatchRequest WithModifiedIndex(int? index = null)
        {
            ModifiedIndex = index;
            return this;
        }

        public IWatchRequest WithRecursive(bool isRecursive = true)
        {
            Recursive = isRecursive;
            return this;
        }

        protected override IDisposable SubscribeCore(IObserver<object> observer)
        {
            throw new NotImplementedException();
        }

    }
}
