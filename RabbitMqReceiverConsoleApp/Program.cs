using System;
using System.Linq;

namespace RabbitMqReceiverConsoleApp
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            var queue = RabbitMqRequestService.GetRabbitMqData();

            if (queue != null)
            {
                foreach (var dateAndShopTransactionIds in queue)
                {
                    Console.WriteLine($"Date: {dateAndShopTransactionIds.DateTime}");

                    foreach (var shopTransactionId in dateAndShopTransactionIds.ShopTransactionIds ?? Enumerable.Empty<string>())
                    {
                        Console.WriteLine($"Id: {shopTransactionId}");
                    }
                    Console.WriteLine();
                }
            }

            Console.ReadKey();
        }
    }
}