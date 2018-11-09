using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vending_machine_mvvm_wpf.Data
{
    public class MoneyStack
    {
        public MoneyStack(Banknote banknote, int amount)
        {
            Banknote = banknote;
            Amount = amount;
        }

        public Banknote Banknote { get; }
        public int Amount { get; }
    }
}
