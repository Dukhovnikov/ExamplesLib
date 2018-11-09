using System;
using System.Xml.Serialization;

namespace xmlTester.ConsoleApp.Models
{
    /// <summary>Представляет ответ на запрос о проведении перевода</summary>
    [XmlRoot("result")]
    public class ProcessResponse
    {
        /// <summary>Уникальный номер транзакции ПСКБ</summary>
        [XmlAttribute("id")]
        public string Id { get; set; }

        /// <summary>Статус перевода / код ответа</summary>
        [XmlAttribute("state")]
        public int State { get; set; }

        /// <summary>Время и дата статуса в формате ГГГГ/ММ/ДД чч:мм:cc</summary>
        [XmlAttribute("state_time")]
        public DateTime DateTime { get; set; }

        /// <summary>Id перевода в БД eKassir</summary>
        [XmlAttribute("serial")]
        public int SerialId { get; set; }

        /// <summary>Комментарий к статусу</summary>
        [XmlAttribute("comment")]
        public string Comment { get; set; }
    }
}
