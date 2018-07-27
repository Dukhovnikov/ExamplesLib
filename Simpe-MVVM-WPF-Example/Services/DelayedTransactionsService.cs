using Simpe_MVVM_WPF_Example.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Simpe_MVVM_WPF_Example.Services
{
    public class DelayedTransactionsService
    {
        private string RabbitMqConnectionString { get; set; }
        private string RabbitMqQueueName { get; set; }

        public void SetConnectionStringAndQueueName(string rabbitMqConnectionString, string rabbitMqQueueName)
        {
            this.RabbitMqConnectionString = rabbitMqConnectionString;
            this.RabbitMqQueueName = rabbitMqQueueName;
        }

        public async void SendToRabbitMqAsync(DateShopTransactionIds dateShopTransactionIds)
        {
            try
            {
                using (var bus = EasyNetQ.RabbitHutch.CreateBus(RabbitMqConnectionString))
                {
                    if (bus.IsConnected)
                    {
                        await bus.SendAsync(RabbitMqQueueName, dateShopTransactionIds);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
    }
}
