using System;
using System.Linq;
using System.Reactive.Disposables;

namespace Draft.Tests
{
    public static class DisposableExtensions
    {

        public static void RegisterDisposable(this IDisposable This, CompositeDisposable disp)
        {
            disp.Add(This);
        }

    }
}
