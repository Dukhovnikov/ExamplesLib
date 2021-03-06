﻿using Prism.Commands;
using Simpe_MVVM_WPF_Example.Models;
using Simpe_MVVM_WPF_Example.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Simpe_MVVM_WPF_Example.ViewModel
{
    public class RabbitMqRequestViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public DateShopTransactionIds DateShopTransactionIds { get; set; }

        public ICommand SendCommand { get; set; }

        public string CommandResult { get; set; }

        public RabbitMqRequestViewModel()
        {
            SendCommand = new DelegateCommand(() => Send());
        }

        private void Send()
        {
            var log = new StringBuilder();
            log.Append("Статус: ");

            try
            {
                var delayedTransactionsService = new DelayedTransactionsService();
                delayedTransactionsService.SetConnectionStringAndQueueName("", "");
                delayedTransactionsService.SendToRabbitMqAsync(DateShopTransactionIds);

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
