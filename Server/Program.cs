using System;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            HttpServer.Run();
            Console.ReadKey();
        }
        
    }
}