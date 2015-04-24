using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Draft
{
    internal sealed class FormBodyBuilder
    {

        private readonly Dictionary<object, object> _items = new Dictionary<object, object>();

        public FormBodyBuilder() {}

        public FormBodyBuilder Add<TKey, TValue>(TKey key, TValue value)
        {
            _items.Add(key, value);
            return this;
        }

        public IDictionary Build()
        {
            return _items;
        }

    }
}
