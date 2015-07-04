using System;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace Draft.Tests
{
    public class XmlValueConverter : IKeyDataValueConverter
    {

        public T Read<T>(string value)
        {
            using (var sr = new StringReader(value))
            {
                var serializer = new XmlSerializer(typeof (T));
                return (T) serializer.Deserialize(sr);
            }
        }

        public string Write<T>(T value)
        {
            using (var sw = new StringWriter())
            {
                var serializer = new XmlSerializer(typeof (T));
                serializer.Serialize(sw, value);
                sw.Flush();
                return sw.ToString();
            }
        }

    }
}
