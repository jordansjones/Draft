using System;
using System.Linq;

namespace Draft.Configuration
{
    internal sealed class ClientConfig : IMutableEtcdClientConfig
    {

        private IKeyDataValueConverter _valueConverter;

        public IKeyDataValueConverter ValueConverter
        {
            get { return _valueConverter ?? (_valueConverter = Converters.Default); }
            set { _valueConverter = value; }
        }

        public ClientConfig DeepCopy()
        {
            return new ClientConfig
            {
                ValueConverter = ValueConverter
            };
        }

    }
}
