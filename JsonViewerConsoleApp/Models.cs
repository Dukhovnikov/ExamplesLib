using System.Collections.Generic;

namespace JsonViewerConsoleApp
{
    public class TaskSettingsWithRabbitMQ : TaskSettings
    {
        public RabbitMQSettings RabbitMqSettings { get; set; }
    }

    public class RabbitMQSettings
    {
        public string RabbitMqQueueName { get; set; }
        public string RabbitMqHostName { get; set; }
        public string RabbitMqUserName { get; set; }
        public string RabbitMqPassword { get; set; }
    }
    
    public class TaskSettings
    {
        public Dictionary<string, string> DestinationToChannelMap { get; set; }
        public string[] IncludeStatuses { get; set; }
        public PaymentMethodMonitorSettings[] Methods { get; set; }
        public int RequestAtHour { get; set; }
        public RecipientSettings To { get; set; }
        
        public class PaymentMethodMonitorSettings
        {
            public string Token { get; set; }
            public Dictionary<string, string> DestinationToChannelMap { get; set; }
            public string[] IncludeStatuses { get; set; }
            public int? RequestAtHour { get; set; }
            public RecipientSettings To { get; set; }
        }

        public class RecipientSettings
        {
            public SmtpSettings Smtp { get; set; }
            public string To { get; set; }
            public string SubjectFormat { get; set; }
            public string DateFormat { get; set; }
            public string SubjectEncoding { get; set; } = "windows-1251";
            public bool IncludeOriginal { get; set; }
        }
    }
    
    public class SmtpSettings
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string From { get; set; }
    }
}