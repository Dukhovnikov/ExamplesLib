using CommonData.ClassLib.Services;
using System.Text;
using xmlTester.ConsoleApp.Models;

namespace xmlTester.ConsoleApp
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            var request = new ProcessRequest()
            {
                Account = "Administator",
                Id = "00000000000000000000000001",
                Service = "totalService",
                Total = 5100
            };
            
            XmlWorker.WriteXmlToDirectory(request);
            XmlWorker.WriteXmlToDirectoryWithEncoding(request, Encoding.UTF8);
        }
    }
}