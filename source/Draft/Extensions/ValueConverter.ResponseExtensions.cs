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
            if (This == null || string.IsNullOrWhiteSpace(This.RawValue))
            {
                return default(T);
            }

            var value = This.RawValue;

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
