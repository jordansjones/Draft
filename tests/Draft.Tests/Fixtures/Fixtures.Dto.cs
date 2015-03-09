using System;
using System.Linq;

using Ploeh.AutoFixture;

namespace Draft.Tests
{
    public static partial class Fixtures
    {

        public static class Dto
        {

            public static SimpleDataContractDto SimpleDataContract(int? id = null, string name = null)
            {
                return new SimpleDataContractDto
                {
                    Id = id ?? Fixture.Create<int>(),
                    Name = name ?? Fixture.Create<string>()
                };
            }

        }

    }
}
