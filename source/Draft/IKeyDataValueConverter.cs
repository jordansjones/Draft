using System;
using System.Linq;

using Draft.Responses;

namespace Draft
{
    /// <summary>
    ///     Converts an <see cref="IKeyData" />'s <code>Value</code> to and from a string.
    /// </summary>
    public interface IKeyDataValueConverter
    {

        /// <summary>
        ///     Converts from the string representation of the object.
        /// </summary>
        /// <param name="value">
        ///     <see cref="IKeyData.RawValue" />
        /// </param>
        /// <returns>The converted result of <paramref name="value" />.</returns>
        object ReadString(string value);

        /// <summary>
        ///     Converts to the string representation of the object.
        /// </summary>
        /// <param name="value">The object to convert.</param>
        /// <returns>The converted result of <paramref name="value" />.</returns>
        string WriteString(object value);

    }

    /// <summary>
    ///     Converts an <see cref="IKeyData" />'s <code>Value</code> to and from a json encoded string.
    /// </summary>
    public interface IJsonKeyDataValueConverter : IKeyDataValueConverter
    {

        /// <summary>
        ///     Converts from the string representation of the object.
        /// </summary>
        /// <param name="value">
        ///     <see cref="IKeyData.RawValue" />
        /// </param>
        /// <returns>The <typeparamref name="T" /> converted result of <paramref name="value" /></returns>
        T ReadString<T>(string value);

    }
}
