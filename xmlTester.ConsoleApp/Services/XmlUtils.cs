using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace xmlTester.ConsoleApp.Services
{
    public static class XmlUtils
    {
        private static readonly Encoding Utf8WithoutBomEncoding = new UTF8Encoding(false);
        public static string Serialize(object obj)
        {
            var ser = new XmlSerializer(obj.GetType());
            using (MemoryStream ms = new MemoryStream())
            {
                Serialize(obj, Utf8WithoutBomEncoding, ms);

                return Encoding.UTF8.GetString(ms.GetBuffer(), 0, (int)ms.Length);
            }
        }

        public static void Serialize(object obj, Encoding encoding, Stream stream)
        {
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            var ser = new XmlSerializer(obj.GetType());
            using (XmlWriter writer = XmlTextWriter.Create(stream, new XmlWriterSettings() { Encoding = encoding }))
            {
                ser.Serialize(writer, obj, ns);
            }
        }

        public static void Serialize(object obj, Encoding encoding, Stream stream, XmlSerializerNamespaces ns)
        {
            var ser = new XmlSerializer(obj.GetType());
            using (XmlWriter writer = XmlTextWriter.Create(stream, new XmlWriterSettings() { Encoding = encoding }))
            {
                ser.Serialize(writer, obj, ns);
            }
        }

        public static TObject Deserialize<TObject>(string content) where TObject : class, new()
        {
            XmlSerializer ser = new XmlSerializer(typeof(TObject));
            using(TextReader reader = new StringReader(content))
            {
                return (TObject)ser.Deserialize(reader);
            }
        }
        public static string ToXml<TObject>(this TObject obj)
        {
            return Serialize(obj);
        }
    }

}