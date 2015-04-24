using System;
using System.Linq;

namespace Draft
{
    internal static class FormBodyBuilderExtensions
    {

        public static FormBodyBuilder Add<TKey, TValue>(this FormBodyBuilder This, bool condition, TKey key, Func<TValue> value)
        {
            if (condition)
            {
                This.Add(key, value());
            }
            return This;
        }

        public static FormBodyBuilder Add<TKey, TValue>(this FormBodyBuilder This, Func<bool> predicate, TKey key, Func<TValue> value)
        {
            return This.Add(predicate(), key, value);
        }

    }
}
