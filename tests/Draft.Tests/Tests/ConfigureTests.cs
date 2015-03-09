using System;

using FluentAssertions;

using System.Linq;

using Xunit;

namespace Draft.Tests
{
    public class ConfigureTests : IDisposable
    {

        public void Dispose()
        {
            // Ensure that the Value Convert is reset to the default
            Etcd.Configure(x => x.ValueConverter = Converters.Default);
        }

        [Fact]
        public void DefaultConfig_ShouldBeJsonConverter()
        {
            Etcd.Configuration.ValueConverter
                .Should()
                .Be(Converters.Json);
        }

        [Fact]
        public void GlobalConfig_ShouldAffectNewInstanceConfig()
        {
            // Ensure Default
            Etcd.Configuration.ValueConverter
                .Should()
                .Be(Converters.Json);

            // Act
            Etcd.Configure(x => x.ValueConverter = Converters.String);

            var client = (EtcdClient) Etcd.ClientFor(Fixtures.EtcdUrl.ToUri());


            // Verify
            client.Config.ValueConverter
                .Should()
                .Be(Converters.String);
        }

        [Fact]
        public void GlobalConfig_ShouldUseTheStringValueConverterWhenConfiguringWithTheStringValueConverter()
        {
            // Ensure Default
            Etcd.Configuration.ValueConverter
                .Should()
                .Be(Converters.Json);

            Etcd.Configure(x => x.ValueConverter = Converters.String);

            Etcd.Configuration.ValueConverter.Should()
                .Be(Converters.String);
        }

        [Fact]
        public void InstanceConfig_ShouldUseTheStringValueConverterWhenConfiguringWithTheStringValueConverter()
        {
            // Ensure Default
            Etcd.Configuration.ValueConverter
                .Should()
                .Be(Converters.Json);

            var client = (EtcdClient) Etcd.ClientFor(Fixtures.EtcdUrl.ToUri());

            client.Configure(x => x.ValueConverter = Converters.String);

            client.Config.ValueConverter
                .Should()
                .Be(Converters.String);
        }

        [Fact]
        public void InstanceConfigure_ShouldNotAffectGlobalConfig()
        {
            // Ensure Default
            Etcd.Configuration.ValueConverter
                .Should()
                .Be(Converters.Json);

            var client = (EtcdClient) Etcd.ClientFor(Fixtures.EtcdUrl.ToUri());

            client.Configure(x => x.ValueConverter = Converters.String);

            client.Config.ValueConverter
                .Should()
                .Be(Converters.String);
            Etcd.Configuration.ValueConverter
                .Should()
                .Be(Converters.Json);
        }

    }
}
