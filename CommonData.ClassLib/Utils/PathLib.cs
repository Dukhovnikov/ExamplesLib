using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CommonData.ClassLib.Utils
{
    public static class PathLib
    {
        private const string PathToJsonFolder = @"C:\Users\dduhovnikov\Documents\GitHub\ExamplesLib\CommonData.ClassLib\Json";
        
        public static string MyDocuments(string additionPath)
        {
            var myDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            return myDocuments + "\\" + additionPath;
        }

        public static IEnumerable<string> JsonPathways()
        {
            return Directory.GetFiles(PathToJsonFolder, "*.json");
        }

        public static string GetJsonFilePath(string jsonFileName)
        {
            return JsonPathways().FirstOrDefault(s => s.Contains(jsonFileName));
        }
    }
}