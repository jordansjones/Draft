using System;
using System.Linq;

using Draft.Responses;

namespace Draft
{
    /// <summary>
    ///     Value conversion extension methods for response objects
    /// </summary>
    public static class ValueConversionForResponseExtensions
    {

        /// <summary>
        ///     Convert the raw value of <paramref name="This" /> key's node.
        /// </summary>
        public static T GetValue<T>(this IKeyData This, IKeyDataValueConverter valueConverter = null)
        {
            if (This == null)
            {
                return default(T);
            }

            var value = This.RawValue;

            var keyData = This as KeyData;

            valueConverter = valueConverter == null && keyData != null ? keyData.ValueConverter() : valueConverter;

            valueConverter = valueConverter ?? Etcd.Configuration.ValueConverter;
            var jsonConverter = valueConverter as IJsonKeyDataValueConverter;
            if (jsonConverter != null)
            {
                return jsonConverter.ReadString<T>(value);
            }

            return (T) valueConverter.ReadString(value);
        }

    }
}
