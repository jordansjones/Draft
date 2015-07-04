using System;
using System.Linq;

using Draft.Responses;
using Draft.ValueConverters;

namespace Draft
{
    /// <summary>
    ///     <see cref="IKeyData.RawValue" /> Converters
    /// </summary>
    public static class Converters
    {

        private static IKeyDataValueConverter _default;

        internal static readonly JsonValueConverter JsonConverter = new JsonValueConverter();

        internal static readonly StringValueConverter StringConverter = new StringValueConverter();

        /// <summary>
        ///     The default converter.
        /// </summary>
        public static IKeyDataValueConverter Default
        {
            get { return _default ?? Json; }
            internal set { _default = value; }
        }

        /// <summary>
        ///     Json based converter.
        /// </summary>
        public static IKeyDataValueConverter Json
        {
            get { return JsonConverter; }
        }

        /// <summary>
        ///     String based converter.
        /// </summary>
        public static IKeyDataValueConverter String
        {
            get { return StringConverter; }
        }

    }
}
