using System;
using System.Linq;

namespace Draft.Requests
{
    public interface IWatchRequest : IObservable<object>
    {

        IWatchRequest WithModifiedIndex(int? index = null);
        IWatchRequest WithRecursive(bool isRecursive = true);

    }
}
