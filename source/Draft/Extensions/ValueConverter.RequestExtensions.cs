using System;
using System.Linq;

using Draft.Configuration;
using Draft.Requests;

namespace Draft
{
    /// <summary>
    ///     Value conversion extension methods for request operations
    /// </summary>
    public static class ValueConversionForRequestExtensions
    {

        private static string Convert<T>(IEtcdClientConfig config, T value, IKeyDataValueConverter valueConverter = null)
        {
            valueConverter = valueConverter ?? (config.ValueConverter ?? Etcd.Configuration.ValueConverter);
            return valueConverter.WriteString(value);
        }

        /// <summary>
        ///     Attempt to delete a key with the expected converted value.
        /// </summary>
        public static ICompareAndDeleteByValueRequest WithExpectedValue<T>(this ICompareAndDeleteRequest This, T value, IKeyDataValueConverter valueConverter = null)
        {
            return This.WithExpectedValue(Convert(This.EtcdClient.Config, value, valueConverter));
        }

        /// <summary>
        ///     Attempt to update a key with the expected converted value.
        /// </summary>
        public static ICompareAndSwapByValueRequest WithExpectedValue<T>(this ICompareAndSwapRequest This, T value, IKeyDataValueConverter valueConverter = null)
        {
            return This.WithExpectedValue(Convert(This.EtcdClient.Config, value, valueConverter));
        }

        /// <summary>
        ///     The new value to convert to a string and set for this key's node.
        /// </summary>
        public static ICompareAndSwapByIndexRequest WithNewValue<T>(this ICompareAndSwapByIndexRequest This, T value, IKeyDataValueConverter valueConverter = null)
        {
            return This.WithNewValue(Convert(This.EtcdClient.Config, value, valueConverter));
        }

        /// <summary>
        ///     The new value to convert to a string and set for this key's node.
        /// </summary>
        public static ICompareAndSwapByValueRequest WithNewValue<T>(this ICompareAndSwapByValueRequest This, T value, IKeyDataValueConverter valueConverter = null)
        {
            return This.WithNewValue(Convert(This.EtcdClient.Config, value, valueConverter));
        }

        /// <summary>
        ///     The value to convert to a string and set for this key's node.
        /// </summary>
        public static IQueueRequest WithValue<T>(this IQueueRequest This, T value, IKeyDataValueConverter valueConverter = null)
        {
            return This.WithValue(Convert(This.EtcdClient.Config, value, valueConverter));
        }

        /// <summary>
        ///     The value to convert to a string and set for this key's node.
        /// </summary>
        public static IUpsertKeyRequest WithValue<T>(this IUpsertKeyRequest This, T value, IKeyDataValueConverter valueConverter = null)
        {
            return This.WithValue(Convert(This.EtcdClient.Config, value, valueConverter));
        }

    }
}
