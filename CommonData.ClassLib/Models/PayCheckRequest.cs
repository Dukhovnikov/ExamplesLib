using Newtonsoft.Json;

namespace CommonData.ClassLib.Models
{
    public class PayCheckRequest
    {
        [JsonProperty("check")]
        public Check Check { get; set; }

        [JsonProperty("client")]
        public Client Client { get; set; }
    }
    
    public class Check
    {
        [JsonProperty("from")]
        public From From { get; set; }

        [JsonProperty("to")]
        public From To { get; set; }
    }

    public class From
    {
        [JsonProperty("provider")]
        public string Provider { get; set; }

        [JsonProperty("account")]
        public string Account { get; set; }

        [JsonProperty("amount")]
        public string Amount { get; set; }

        [JsonProperty("currency")]
        public long Currency { get; set; }
    }

    public class Client
    {
        [JsonProperty("wal_id")]
        public string WalId { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }
    }
}