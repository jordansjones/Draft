using System;
using System.Linq;

namespace Draft.ValueConverters
{
    internal class StringValueConverter : IKeyDataValueConverter
    {


        public object ReadString(string value)
        {
            return value;
        }

        public string WriteString(object value)
        {
            var strValue = value as string;
            if (strValue != null) { return strValue; }


            return Convert.ToString(value);
        }

    }
}
