using System;
using System.IO;
using System.Net;
using CommonData.ClassLib.Settings;
using CommonData.ClassLib.Utils;

namespace Client
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            var jsonRequestPath = PathLib.GetJsonFilePath("pay_check_request");
            var jsonRequest = File.ReadAllText(jsonRequestPath);
            Console.WriteLine(jsonRequest.Length);
            
            
            HttpSender.SendRestSharp(jsonRequest);

            //var cli = new WebClient {Headers = {[HttpRequestHeader.ContentType] = "application/json"}};
            //var response = cli.UploadString(HttpSettings.Address, jsonRequest);
            //Console.ReadKey();
        }
    }
}