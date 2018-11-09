using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vending_machine_mvvm_wpf.Data;

namespace vending_machine_mvvm_wpf.Model
{
    public class User
    {
        public int UserSumm { get; set; }
        public ReadOnlyObservableCollection<MoneyStack> UserWallet { get; }
        private readonly ObservableCollection<MoneyStack> _userWallet;
    }
}
