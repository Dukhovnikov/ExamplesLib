using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using CommonData.ClassLib.Settings;
using CommonData.ClassLib.Utils;

namespace Server
{
    public static class HttpServer
    {
        public static void RunAndWaiting()
        {
            var thread = new Thread(Run);
            thread.Start();
            Console.ReadKey();
        }
       
        public static async void Run()
        {
            var listener = new HttpListener();
            listener.Prefixes.Add(HttpSettings.Address);
            listener.Start();

            Console.WriteLine($"Http server is run. Current address: {HttpSettings.Address}");
            var counter = new ConsoleCounter();

            while (true)
            {
                HttpListenerContext context = await listener.GetContextAsync();
                HttpListenerRequest request = context.Request;
                HttpListenerResponse response = context.Response;

                counter.Show();
                counter.Tick();
                
                var jsonRequest = GetJsonFromStream(request.InputStream);
                ColorWriter.WriteLine($"Message was recived:\n\n{jsonRequest}\n", ConsoleColor.Blue);
            }
        }

        public static async void RunWithTest(ISettings settings)
        {
            HttpListener listener = new HttpListener();
            listener.Prefixes.Add(settings.Address);
            listener.Start();

            Console.WriteLine($"Http server is run. Current address: {settings.Address}");
            ConsoleCounter counter = new ConsoleCounter();

            while (true)
            {
                HttpListenerContext context = await listener.GetContextAsync();
                HttpListenerRequest request = context.Request;
                HttpListenerResponse response = context.Response;

                WebServer das = null;

                counter.Show();
                counter.Tick();

                var jsonRequest = GetJsonFromStream(request.InputStream);
                ColorWriter.WriteLine($"Message was recived:\n\n{jsonRequest}\n", ConsoleColor.Blue);
            }
        }

        private static string GetJsonFromStream(Stream stream)
        {
            string jsonString;

            using (var inputStream = new StreamReader(stream))
            {
                jsonString = inputStream.ReadToEnd();
            }

            return jsonString;
        }

        private static async Task Listen()
        {
            HttpListener listener = new HttpListener();
            listener.Prefixes.Add("http://localhost:8888/testhttpserver/");
            listener.Start();
            Console.WriteLine("Ожидание подключений...");

            var iterationCount = 0;


            while (true)
            {
                HttpListenerContext context = await listener.GetContextAsync();
                HttpListenerRequest request = context.Request;
                HttpListenerResponse response = context.Response;

                string responseString = "<html><head><meta charset='utf8'></head><body>Привет мир!</body></html>";
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
                response.ContentLength64 = buffer.Length;
                Stream output = response.OutputStream;
                output.Write(buffer, 0, buffer.Length);
                output.Close();

                Console.WriteLine($"Принято {iterationCount} сообщение");
                iterationCount++;
            }
        }

        private static void Rudiment()
        {
            HttpListener listener = new HttpListener();
            // установка адресов прослушки
            listener.Prefixes.Add("http://localhost:8888/connection/");
            listener.Start();
            Console.WriteLine("Ожидание подключений...");
            // метод GetContext блокирует текущий поток, ожидая получение запроса 
            HttpListenerContext context = listener.GetContext();
            HttpListenerRequest request = context.Request;
            // получаем объект ответа
            HttpListenerResponse response = context.Response;
            // создаем ответ в виде кода html
            string responseStr = "<html><head><meta charset='utf8'></head><body>Привет мир!</body></html>";
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseStr);
            // получаем поток ответа и пишем в него ответ
            response.ContentLength64 = buffer.Length;
            Stream output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);
            // закрываем поток
            output.Close();
            // останавливаем прослушивание подключений
            listener.Stop();
            Console.WriteLine("Обработка подключений завершена");
            Console.Read();
        }
    }
}