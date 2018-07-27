using System.Collections.Generic;

namespace JsonViewerConsoleApp
{
    public static class ModelService
    {
        public static TaskSettingsWithRabbitMQ GetTestSetting()
        {
            var taskSettingsWithRabbitMq = new TaskSettingsWithRabbitMQ()
            {
                DestinationToChannelMap = new Dictionary<string, string>()
                {
                    {"1", "BC"}
                },
                RequestAtHour = 3,
                IncludeStatuses = new[] {"PAID"},
                Methods = new TaskSettings.PaymentMethodMonitorSettings[]
                    {new TaskSettings.PaymentMethodMonitorSettings() {Token = null},},
                To = new TaskSettings.RecipientSettings()
                {
                    To = "dduhovnikov@baltbet.ru",
                    DateFormat = "yyyy-MM-dd",
                    SubjectEncoding = "windows-1251",
                    SubjectFormat = "Реестр Winpay [{date}]",
                    IncludeOriginal = true,
                    Smtp = new SmtpSettings()
                    {
                        From = "payments@baltbet.ru",
                        Host = "smtp.baltbet.com",
                        Port = 25,
                        Password = "",
                        UserName = "payments"
                    }
                },
                RabbitMqSettings = new RabbitMQSettings()
                {
                    RabbitMqHostName = "http://localhost",
                    RabbitMqPassword = "guest",
                    RabbitMqQueueName = "testqueue",
                    RabbitMqUserName = "guest"
                }
            };

            return taskSettingsWithRabbitMq;
        }
    }
}