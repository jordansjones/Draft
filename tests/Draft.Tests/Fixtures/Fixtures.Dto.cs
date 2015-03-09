using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

using Newtonsoft.Json;

using Ploeh.AutoFixture;

namespace Draft.Tests
{
    public static partial class Fixtures
    {

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public static class Dto
        {

            public const int Json_SimpleDataContract_Id = 1234;

            public const string Json_SimpleDataContract_Name = "Draft";

            public static SimpleDataContractDto SimpleDataContract(int? id = null, string name = null)
            {
                return new SimpleDataContractDto
                {
                    Id = id ?? Fixture.Create<int>(),
                    Name = name ?? Fixture.Create<string>()
                };
            }

            public static readonly string Json_SimpleDataContract = JsonConvert.SerializeObject(SimpleDataContract(Json_SimpleDataContract_Id, Json_SimpleDataContract_Name));

        }

    }
}
