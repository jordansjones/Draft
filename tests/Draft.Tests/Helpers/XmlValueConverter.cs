using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Draft.Tests
{
    public class XmlValueConverter<T> : IKeyDataValueConverter
    {

        public XmlValueConverter()
        {
            XmlSerializer = new XmlSerializer(typeof (T));
        }

        public XmlSerializer XmlSerializer { get; private set; }

        public object ReadString(string value)
        {
            using (var sr = new StringReader(value))
            {
                return XmlSerializer.Deserialize(sr);
            }
        }

        public string WriteString(object value)
        {
            var sb = new StringBuilder();
            using (var sw = new StringWriter(sb))
            {
                XmlSerializer.Serialize(sw, value);
            }

            return sb.ToString();
        }

    }
}
