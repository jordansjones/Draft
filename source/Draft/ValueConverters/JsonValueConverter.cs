using System;
using System.Linq;

using Newtonsoft.Json;

namespace Draft.ValueConverters
{
    internal class JsonValueConverter : IKeyDataValueConverter
    {

        public object ReadString(string value)
        {
            return DeserializeString<object>(value);
        }

        public string WriteString(object value)
        {
            return JsonConvert.SerializeObject(value);
        }

        public T DeserializeString<T>(string value)
        {
            return JsonConvert.DeserializeObject<T>(value);
        }

    }
}
