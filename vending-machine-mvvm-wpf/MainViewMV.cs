using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using vending_machine_mvvm_wpf.Model;

namespace vending_machine_mvvm_wpf
{
    public class MainViewMV : BindableBase
    {
        private User _user;

        public MainViewMV()
        {
            _user = new User();
        }

        public int UserSumm => _user.UserSumm;
        public ObservableCollection<MoneyMV> UserWallet { get; }
        public ObservableCollection<ProductMV> UserBuyings { get; }
        public DelegateCommand GetChange { get; }
        public int Credit { get; }
        public ReadOnlyObservableCollection<MoneyMV> AutomataBank { get; }
        public ReadOnlyObservableCollection<ProductMV> ProductsInAutomata { get; }
    }

    public class ProductMV
    {
        public Visibility IsBuyVisible { get; }
        public DelegateCommand BuyCommand { get; }
        public string Name { get; }
        public string Price { get; }
        public int Amount { get; }
    }

    public class MoneyMV
    {
        public Visibility IsInsertVisible { get; }
        public DelegateCommand InsertCommand { get; }
        public string Name { get; }
        public int Amount { get; }
    }
}
