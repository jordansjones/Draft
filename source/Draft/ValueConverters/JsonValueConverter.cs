using System;
using System.Linq;

using Newtonsoft.Json;

namespace Draft.ValueConverters
{
    internal class JsonValueConverter : IJsonKeyDataValueConverter
    {

        public T ReadString<T>(string value)
        {
            return JsonConvert.DeserializeObject<T>(value);
        }

        public object ReadString(string value)
        {
            return ReadString<object>(value);
        }

        public string WriteString(object value)
        {
            return JsonConvert.SerializeObject(value);
        }

    }
}
