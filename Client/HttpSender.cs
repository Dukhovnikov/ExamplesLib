using System;
using System.Net;
using CommonData.ClassLib.Settings;
using RestSharp;

namespace Client
{
    public class HttpSender
    {
        public static void SendRestSharp(string data)
        {
            try
            {
                var client = new RestClient(HttpSettings.Address);

                var request = new RestRequest(Method.POST);
                request.AddParameter("application/json; charset=utf-8", data, ParameterType.RequestBody);
                
                var response = client.Execute(request);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Client.HttpSender.SendRestSharp - have some error");
            }
        }

        public static void SendWebClent(string data)
        {
            try
            {
                using (var client = new WebClient())
                {
                    client.Headers.Add(HttpRequestHeader.ContentType,"application/json");
                    var response = client.UploadString(HttpSettings.Address, data);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Client.HttpSender.SendWebClent - have some error");
            }
        }
    }
}