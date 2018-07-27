﻿using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using EasyNetQ.Management.Client;
using EasyNetQ.Management.Client.Model;

namespace RabbitMqReceiverConsoleApp
{
    public static class RabbitMqRequestService
    {
        public static IEnumerable<DateAndShopTransactionIds> GetRabbitMqData(int maxMessagesPerJobCount = 200)
        {
            using (var management = new ManagementClient("http://localhost", "guest", "guest"))
            {
                var vhost = management.GetVhostAsync("/").Result;
                var queue = management.GetQueueAsync("testqueue", vhost).Result;

                if (queue.MessagesReady > 0)
                {
                    var messagesPack = management.GetMessagesFromQueueAsync(queue,
                        new ExtendedGetMessagesCriteria(maxMessagesPerJobCount, false, "ack_requeue_true")).Result;

                    return messagesPack.Select(message =>
                        JsonConvert.DeserializeObject<DateAndShopTransactionIds>(message.Payload));
                }
            }

            return null;
        }
    }
    
    public class DateAndShopTransactionIds
    {
        public DateTime DateTime { get; set; }
        public string[] ShopTransactionIds { get; set; }
    }
    
    public class ExtendedGetMessagesCriteria : GetMessagesCriteria
    {
        public ExtendedGetMessagesCriteria(long count, bool requeue, string ackMode) : base(count, requeue)
        {    
            this.Ackmode = ackMode;
        }
        public string Ackmode { get; private set; }
    }
}