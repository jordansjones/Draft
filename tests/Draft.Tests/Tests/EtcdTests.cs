using System;
using System.Linq;

using FluentAssertions;

using Xunit;

namespace Draft.Tests
{
    public class EtcdTests
    {

        [Fact]
        public void ShouldThrowArgumentExceptionOnRelativeUri()
        {
            Action action = CreateWithRelativeUrl;
            action.ShouldThrowExactly<ArgumentException>();
        }

        private static void CreateWithRelativeUrl()
        {
            Etcd.ClientFor(new Uri(Fixtures.RelativeEtcdUrl, UriKind.Relative));
        }

    }
}
