using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Draft.Tests
{
    public class FormBodyBuilder<TKey, TValue>
    {

        private readonly Draft.ListDictionary _items = new Draft.ListDictionary();

        public FormBodyBuilder() {}

        public FormBodyBuilder(IDictionary existing)
        {
            foreach (var key in existing.Keys)
            {
                _items.Add((TKey) key, (TValue) existing[key]);
            }
        }

        public FormBodyBuilder(IEnumerable<KeyValuePair<TKey, TValue>> existing)
        {
            foreach (var item in existing)
            {
                _items.Add(item.Key, item.Value);
            }
        }

        public FormBodyBuilder<TKey, TValue> Add(TKey key, TValue value)
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
