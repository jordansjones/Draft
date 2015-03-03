using System;
using System.Linq;

using Draft.Responses;

namespace Draft.Configuration
{
    /// <summary>
    ///     A set of properties taht affect <see cref="IEtcdClient" /> behavior.
    /// </summary>
    public interface IEtcdClientConfig
    {

        /// <summary>
        /// <see cref="IKeyDataValueConverter" /> to use for <see cref="IKeyData.Value" />.
        /// </summary>
        IKeyDataValueConverter ValueConverter { get; set; }

    }
}
