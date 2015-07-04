using System;
using System.ComponentModel;
using System.Linq;

namespace Draft.ValueConverters
{
    internal class StringValueConverter : IKeyDataValueConverter
    {

        private static readonly Type StringType = typeof (string);

        public T Read<T>(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return default(T);
            }

            var tType = typeof (T);

            if (tType.IsEnum)
            {
                return (T) Enum.Parse(tType, value, true);
            }

            var converter = TypeDescriptor.GetConverter(StringType);
            if (converter.CanConvertTo(tType))
            {
                return (T) converter.ConvertTo(value, tType);
            }

            converter = TypeDescriptor.GetConverter(tType);
            if (converter.CanConvertFrom(StringType))
            {
                return (T) converter.ConvertFromString(value);
            }

            return (T) Convert.ChangeType(value, tType);
        }

        public string Write<T>(T value)
        {
            if (value == null) { return string.Empty; }

            if (value is Enum)
            {
                return Enum.GetName(value.GetType(), value);
            }

            var tType = typeof (T);
            var converter = TypeDescriptor.GetConverter(tType);
            if (converter.CanConvertTo(StringType))
            {
                return converter.ConvertToString(value);
            }

            converter = TypeDescriptor.GetConverter(StringType);
            if (converter.CanConvertFrom(tType))
            {
                return converter.ConvertToString(value);
            }

            return (string) Convert.ChangeType(value, StringType);
        }

        public object ReadString(string value)
        {
            return Read<object>(value);
        }

        public string WriteString(object value)
        {
            var strValue = value as string;
            if (strValue != null) { return strValue; }


            return Write(value);
        }

    }
}
