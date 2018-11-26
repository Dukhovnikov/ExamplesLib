using Server.Interfaces;
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Server
{
    public class Server : IServer
    {
        public static int Port { get; } = 8005;
        public static string Address { get; } = "127.0.0.1";
        
        public static IPEndPoint IpPoint = new IPEndPoint(IPAddress.Parse(Address), Port);
        public static Socket ListenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        public void Start()
        {
            ListenSocket.Bind(IpPoint);
            ListenSocket.Listen(10);
            
            Console.WriteLine("Сервер запущен. Ожидание подключений...");

            while (true)
            {
                
            }
        }

        public Task Run()
        {
            throw new NotImplementedException();
        }
    }
}