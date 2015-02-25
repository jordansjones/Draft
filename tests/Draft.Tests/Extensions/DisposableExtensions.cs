using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reactive.Disposables;

namespace Draft.Tests
{
    [ExcludeFromCodeCoverage]
    public static class DisposableExtensions
    {

        public static void RegisterDisposable(this IDisposable This, CompositeDisposable disp)
        {
            disp.Add(This);
        }

    }
}
