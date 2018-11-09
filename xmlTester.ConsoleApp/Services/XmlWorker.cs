using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using CommonData.ClassLib;
using CommonData.ClassLib.Utils;

namespace xmlTester.ConsoleApp.Services
{
    public static class XmlWorker
    {
        public static void WriteXmlToDirectory(object obj)
        {
            var formatter = new XmlSerializer(obj.GetType());

            var fileName = obj.ToString() + ".xml";
            using (var fStream = new FileStream(PathLib.MyDocuments(fileName), FileMode.OpenOrCreate))
            {
                formatter.Serialize(fStream, obj);
                
                Console.WriteLine("Success...");
            }
        }
        
        public static void WriteXmlToDirectoryWithEncoding(object obj, Encoding encoding)
        {
            var formatter = new XmlSerializer(obj.GetType());

            var fileName = obj.ToString() + ".Encoding.xml";
            using (var fStream = new FileStream(PathLib.MyDocuments(fileName), FileMode.OpenOrCreate))
            {
                using (var xmlWriter = XmlWriter.Create(fStream, new XmlWriterSettings(){Encoding = encoding}))
                {
                    formatter.Serialize(xmlWriter, obj);
                }
                
                Console.WriteLine("Success...");
            }
        }
    }
}