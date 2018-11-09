using mvvm_wpf_example.Models;
using mvvm_wpf_example.Services;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace mvvm_wpf_example.ViewModel
{
    public class RabbitMqRequestViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public DateShopTransactionIds DateShopTransactionIds => new DateShopTransactionIds() { Date = Date, ShopTransactionIds = Numbers.Split('\n') };

        public DateTime Date { get; set; }

        public string Numbers { get; set; }

        public ICommand SendCommand { get; set; }

        public string CommandResult { get; set; }

        public RabbitMqRequestViewModel()
        {
            SendCommand = new DelegateCommand(() => Send(DateShopTransactionIds));
        }

        private void Send(DateShopTransactionIds dateShopTransactionIds)
        {
            var log = new StringBuilder();
            log.Append("Статус: ");

            try
            {
                var delayedTransactionsService = new DelayedTransactionsService();
                delayedTransactionsService.SetConnectionStringAndQueueName("host=localhost", "testqueue");
                delayedTransactionsService.SendToRabbitMqAsync(dateShopTransactionIds);

                log.Append($"Успешно выполнено в {DateTime.Now.ToLongTimeString()}");
            }
            catch (Exception)
            {
                log.Append($"Операция не выполнена {DateTime.Now.ToLongTimeString()}");
            }
            finally
            {
                CommandResult = log.ToString();
            }

        }
    }
}
