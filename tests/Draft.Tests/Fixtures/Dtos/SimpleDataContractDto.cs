using System;
using System.Linq;
using System.Runtime.Serialization;

namespace Draft.Tests
{
    [DataContract]
    public class SimpleDataContractDto
    {

        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "NAME")]
        public string Name { get; set; }

    }
}
