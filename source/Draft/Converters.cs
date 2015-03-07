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

        internal static readonly JsonValueConverter JsonConverter = new JsonValueConverter();

        internal static readonly StringValueConverter StringConverter = new StringValueConverter();

        static Converters()
        {
            Default = Json;
        }

        /// <summary>
        ///     The default converter.
        /// </summary>
        public static IKeyDataValueConverter Default { get; internal set; }

        /// <summary>
        ///     Json based converter.
        /// </summary>
        public static IJsonKeyDataValueConverter Json
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
