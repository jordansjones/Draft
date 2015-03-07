using System;
using System.Diagnostics.CodeAnalysis;

using Draft.Responses;

using System.Linq;

using Newtonsoft.Json;

namespace Draft.Json
{
    [ExcludeFromCodeCoverage]
    internal class EtcdErrorCodeConverter : JsonConverter
    {

        public override bool CanConvert(Type objectType)
        {
            var nullableType = Nullable.GetUnderlyingType(objectType);

            var t = (nullableType == null || objectType == nullableType)
                ? objectType
                : nullableType;

            return t.IsEnum
                   && t == typeof (EtcdErrorCode);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) { return null; }

            if (reader.TokenType == JsonToken.Integer)
            {
                return Convert.ToInt32(reader.Value).Map();
            }
            if (reader.TokenType == JsonToken.String)
            {
                int output;
                if (int.TryParse(Convert.ToString(reader.Value), out output))
                {
                    return output.Map();
                }
            }

            return null;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (!(value is EtcdErrorCode))
            {
                writer.WriteNull();
                return;
            }

            var code = (EtcdErrorCode) value;

            writer.WriteValue(code.RawValue());
        }

    }
}
