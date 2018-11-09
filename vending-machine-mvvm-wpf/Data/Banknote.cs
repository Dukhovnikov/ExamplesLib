using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vending_machine_mvvm_wpf.Data
{
    public struct Banknote
    {
        public static readonly IReadOnlyList<Banknote> banknotes = new[]
        {
            new Banknote("Рубль", 1, true),
            new Banknote("Два рубля", 2, true),
            new Banknote("Пять рублей", 5, true),
            new Banknote("Десять рублей", 10, false),
            new Banknote("Пятьдесят рублей", 50, false),
            new Banknote("Сто рублей", 100, false)
        };

        public Banknote(string name, int nominal, bool isCoin)
        {
            Name = name;
            Nominal = nominal;
            IsCoin = isCoin;
        }

        public string Name { get; }
        public int Nominal { get; }
        public bool IsCoin { get; } //монета ли это. Нужно для красоты
    }
}
