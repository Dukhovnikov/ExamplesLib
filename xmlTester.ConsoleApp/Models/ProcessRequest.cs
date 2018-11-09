using System;
using System.Xml.Serialization;

namespace xmlTester.ConsoleApp.Models
{
    /// <summary>Запрос на проведение перевода ПСКБ</summary>
    [XmlRoot("process", IsNullable = false)]
    public class ProcessRequest
    {
        /// <summary>Уникальный номер транзакции ПСКБ</summary>
        [XmlAttribute("id")]
        public string Id { get; set; }

        /// <summary>Alias (псевдоним) услуги</summary>
        [XmlAttribute("account")]
        public string Account { get; set; }

        /// <summary>Номер телефона, счета и т.д. Проходит дополнительную проверку на стороне шлюза</summary>
        [XmlAttribute("service")]
        public string Service { get; set; }

        /// <summary>Сумма перевода</summary>
        [XmlAttribute("total")]
        public decimal Total { get; set; }
    }
}