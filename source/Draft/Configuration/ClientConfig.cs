using System;
using System.Linq;

namespace Draft.Configuration
{
    internal sealed class ClientConfig : IEtcdClientConfig
    {

        private IKeyDataValueConverter _valueConverter;

        public IKeyDataValueConverter ValueConverter
        {
            get
            {
                if (_valueConverter == null)
                {
                    _valueConverter = Converters.Default;
                }
                return _valueConverter;
            }
            set { _valueConverter = value; }
        }

    }
}