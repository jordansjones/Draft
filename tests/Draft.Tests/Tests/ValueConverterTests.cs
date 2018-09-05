using System;

using FluentAssertions;

using Flurl;

using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

using Flurl.Http.Testing;

using Newtonsoft.Json;

using Xunit;

namespace Draft.Tests
{
    public class ValueConverterTests
    {

        [Fact]
        public async Task Get_ShouldUseConfiguredValueConverter()
        {
            var dto = Fixtures.Dto.SimpleDataContract();
            var converter = new XmlValueConverter();
            var expected = converter.Write(dto);

            using (var http = new HttpTest())
            {
                http.RespondWithJson(Fixtures.Key.UpsertResponse(Fixtures.Key.Path, expected));

                var client = Etcd.ClientFor(Fixtures.EtcdUrl.ToUri());
                client.Configure(x => x.ValueConverter = converter);

                var response = await client
                    .GetKey(Fixtures.Key.Path);

                http.Should()
                    .HaveCalled(
                        Fixtures.EtcdUrl
                            .AppendPathSegments(Constants.Etcd.Path_Keys, Fixtures.Key.Path)
                    )
                    .WithVerb(HttpMethod.Get)
                    .Times(1);

                response.Should().NotBeNull();
                response.Data.Should().NotBeNull();
                response.Data.RawValue.Should().NotBeNullOrWhiteSpace();
                response.Data.RawValue.Should().Be(expected);

                SimpleDataContractDto responseDto = null;
                Action getValue = () => responseDto = response.Data.GetValue<SimpleDataContractDto>();
                getValue.Should().NotThrow();

                responseDto.Should().NotBeNull();

                responseDto.Id.Should().Be(dto.Id);
                responseDto.Name.Should().Be(dto.Name);
            }
        }

        [Fact]
        public async Task Get_ShouldUsePassedValueConverter()
        {
            var dto = Fixtures.Dto.SimpleDataContract();
            var converter = new XmlValueConverter();
            var expected = converter.Write(dto);

            using (var http = new HttpTest())
            {
                http.RespondWithJson(Fixtures.Key.UpsertResponse(Fixtures.Key.Path, expected));

                var response = await Etcd.ClientFor(Fixtures.EtcdUrl.ToUri())
                    .GetKey(Fixtures.Key.Path);

                http.Should()
                    .HaveCalled(
                        Fixtures.EtcdUrl
                            .AppendPathSegments(Constants.Etcd.Path_Keys, Fixtures.Key.Path)
                    )
                    .WithVerb(HttpMethod.Get)
                    .Times(1);

                response.Should().NotBeNull();
                response.Data.Should().NotBeNull();
                response.Data.RawValue.Should().NotBeNullOrWhiteSpace();
                response.Data.RawValue.Should().Be(expected);

                SimpleDataContractDto responseDto = null;
                Action getValue = () => responseDto = response.Data.GetValue<SimpleDataContractDto>(converter);
                getValue.Should().NotThrow();

                responseDto.Should().NotBeNull();

                responseDto.Id.Should().Be(dto.Id);
                responseDto.Name.Should().Be(dto.Name);
            }
        }

        [Fact]
        public void JsonConverter_ShouldDeserializeTypeCorrectly()
        {
            var result = Converters.Json.Read<SimpleDataContractDto>(Fixtures.Dto.Json_SimpleDataContract);

            result.Should().NotBeNull();

            result.Id.Should().Be(Fixtures.Dto.Json_SimpleDataContract_Id);
            result.Name.Should().NotBeNullOrWhiteSpace()
                .And.Be(Fixtures.Dto.Json_SimpleDataContract_Name);
        }

        [Fact]
        public void StringConverter_ShouldDeserializeCorrectly()
        {
            var result = Converters.String.Read<string>(Fixtures.Dto.Json_SimpleDataContract_Name);

            result.Should().NotBeNull();
            result.Should().Be(Fixtures.Dto.Json_SimpleDataContract_Name);
        }

        [Fact]
        public void StringConverter_ShouldDoNothingWithStringParameterOnWriteStringMethod()
        {
            var result = Converters.String.Write(Fixtures.Dto.Json_SimpleDataContract_Name);

            result.Should().NotBeNull();
            result.Should().Be(Fixtures.Dto.Json_SimpleDataContract_Name);
        }

        [Fact]
        public async Task Upsert_ShouldHaveTheJsonEncodedBodyWhenUsingTheJsonValueConverter()
        {
            var dto = Fixtures.Dto.SimpleDataContract();
            var expected = JsonConvert.SerializeObject(dto);
            using (var http = new HttpTest())
            {
                http.RespondWithJson(Fixtures.Key.DefaultResponse);

                var client = Etcd.ClientFor(Fixtures.EtcdUrl.ToUri());
                client.Configure(x => x.ValueConverter = Converters.Json);

                await client
                    .UpsertKey(Fixtures.Key.Path)
                    .WithValue(dto);

                http.Should()
                    .HaveCalled(
                        Fixtures.EtcdUrl
                            .AppendPathSegments(Constants.Etcd.Path_Keys, Fixtures.Key.Path)
                    )
                    .WithVerb(HttpMethod.Put)
                    .WithRequestBody(Fixtures.Key.DefaultRequest(expected))
                    .Times(1);
            }
        }

        [Fact]
        public async Task Upsert_ShouldHaveTheStringEncodedBodyWhenUsingTheStringValueConverter()
        {
            const long dto = 389L;
            var expected = Convert.ToString(dto);
            using (var http = new HttpTest())
            {
                http.RespondWithJson(Fixtures.Key.DefaultResponse);

                var client = Etcd.ClientFor(Fixtures.EtcdUrl.ToUri());
                client.Configure(x => x.ValueConverter = Converters.String);

                await client
                    .UpsertKey(Fixtures.Key.Path)
                    .WithValue(dto);

                http.Should()
                    .HaveCalled(
                        Fixtures.EtcdUrl
                            .AppendPathSegments(Constants.Etcd.Path_Keys, Fixtures.Key.Path)
                    )
                    .WithVerb(HttpMethod.Put)
                    .WithRequestBody(Fixtures.Key.DefaultRequest(expected))
                    .Times(1);
            }
        }

        [Fact]
        public async Task Upsert_ShouldUsedPassedValueConverter()
        {
            var dto = Fixtures.Dto.SimpleDataContract();
            var converter = new XmlValueConverter();
            var expected = converter.Write(dto);

            using (var http = new HttpTest())
            {
                http.RespondWithJson(Fixtures.Key.DefaultResponse);

                await Etcd.ClientFor(Fixtures.EtcdUrl.ToUri())
                    .UpsertKey(Fixtures.Key.Path)
                    .WithValue(dto, converter);

                http.Should()
                    .HaveCalled(
                        Fixtures.EtcdUrl
                            .AppendPathSegments(Constants.Etcd.Path_Keys, Fixtures.Key.Path)
                    )
                    .WithVerb(HttpMethod.Put)
                    .WithRequestBody(Fixtures.Key.DefaultRequest(expected))
                    .Times(1);
            }
        }

    }
}
