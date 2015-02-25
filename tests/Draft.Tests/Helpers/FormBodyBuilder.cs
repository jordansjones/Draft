using System;
using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Draft.Tests
{
    [ExcludeFromCodeCoverage]
    public class FormBodyBuilder<TKey, TValue>
    {

        private readonly ListDictionary _items = new ListDictionary();

        public FormBodyBuilder() {}

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
