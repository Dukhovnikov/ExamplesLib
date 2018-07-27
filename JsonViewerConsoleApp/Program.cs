using System.IO;
using System.Security.Cryptography.X509Certificates;
using Newtonsoft.Json;

namespace JsonViewerConsoleApp
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            var settings = ModelService.GetTestSetting();
            var jsonSettings = JsonConvert.SerializeObject(settings, Formatting.Indented);
            File.WriteAllText(@"D:\forTests\jsonSetting.txt",jsonSettings);
        }
    }
}