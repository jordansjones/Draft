using System;
using System.Linq;

using Draft.Responses;

namespace Draft.Configuration
{
    /// <summary>
    ///     A set of properties that affect <see cref="IEtcdClient" /> behavior.
    /// </summary>
    public interface IEtcdClientConfig
    {

        /// <summary>
        ///     <see cref="IKeyDataValueConverter" /> to use for <see cref="IKeyData.RawValue" />.
        /// </summary>
        IKeyDataValueConverter ValueConverter { get; }

    }

    /// <summary>
    ///     A set of properties that affect <see cref="IEtcdClient" /> behavior.
    /// </summary>
    public interface IMutableEtcdClientConfig : IEtcdClientConfig
    {

        /// <summary>
        ///     <see cref="IKeyDataValueConverter" /> to use for <see cref="IKeyData.RawValue" />.
        /// </summary>
        new IKeyDataValueConverter ValueConverter { get; set; }

    }
}
