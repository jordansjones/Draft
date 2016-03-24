using System;
using System.Linq;

using Draft.Requests;

namespace Draft
{
    /// <summary>
    ///     Additional TimeToLive extensions methods for request operations
    /// </summary>
    public static class TimeToLiveExtensions
    {

        private static T ApplyTimeToLive<T>(this T This, TimeSpan? timeSpan, Func<T, long, T> func)
        {
            return timeSpan.HasValue
                ? func(This, Convert.ToInt64(timeSpan.Value.TotalSeconds))
                : This;
        }

        /// <summary>
        ///     An optional expiration for this key.
        /// </summary>
        public static ICompareAndSwapByIndexRequest WithTimeToLive(this ICompareAndSwapByIndexRequest This, TimeSpan? timeSpan)
        {
            return This.ApplyTimeToLive(timeSpan, (x, y) => x.WithTimeToLive(y));
        }

        /// <summary>
        ///     An optional expiration for this key.
        /// </summary>
        public static ICompareAndSwapByValueRequest WithTimeToLive(this ICompareAndSwapByValueRequest This, TimeSpan? timeSpan)
        {
            return This.ApplyTimeToLive(timeSpan, (x, y) => x.WithTimeToLive(y));
        }

        /// <summary>
        ///     An optional expiration for this key.
        /// </summary>
        public static ICreateDirectoryRequest WithTimeToLive(this ICreateDirectoryRequest This, TimeSpan? timeSpan)
        {
            return This.ApplyTimeToLive(timeSpan, (x, y) => x.WithTimeToLive(y));
        }

        /// <summary>
        ///     An optional expiration for this key.
        /// </summary>
        public static IQueueRequest WithTimeToLive(this IQueueRequest This, TimeSpan? timeSpan)
        {
            return This.ApplyTimeToLive(timeSpan, (x, y) => x.WithTimeToLive(y));
        }

        /// <summary>
        ///     An optional expiration for this key.
        /// </summary>
        public static IUpdateDirectoryRequest WithTimeToLive(this IUpdateDirectoryRequest This, TimeSpan? timeSpan)
        {
            return This.ApplyTimeToLive(timeSpan, (x, y) => x.WithTimeToLive(y));
        }

        /// <summary>
        ///     An optional expiration for this key.
        /// </summary>
        public static IUpsertKeyRequest WithTimeToLive(this IUpsertKeyRequest This, TimeSpan? timeSpan)
        {
            return This.ApplyTimeToLive(timeSpan, (x, y) => x.WithTimeToLive(y));
        }

    }
}
