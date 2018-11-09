using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using vending_machine_mvvm_wpf.Data;
using vending_machine_mvvm_wpf.Model;

namespace vending_machine_mvvm_wpf
{
    public class MainViewMV : BindableBase
    {
        private User _user;

        public MainViewMV()
        {
            _user = new User();

            //UserWallet = new ObservableCollection<MoneyVM>(_user.UserWallet.Select(ms => new MoneyVM(ms)));
            //((INotifyCollectionChanged)_user.UserWallet).CollectionChanged += (s, a) =>
            //{
            //    if (a.NewItems?.Count == 1) UserWallet.Add(new MoneyVM(a.NewItems[0] as MoneyStack));
            //    if (a.OldItems?.Count == 1) UserWallet.Remove(UserWallet.First(mv => mv.MoneyStack == a.OldItems[0]));
            //};
        }

        public int UserSumm => _user.UserSumm;
        public ObservableCollection<MoneyVM> UserWallet { get; }
        public ObservableCollection<ProductMV> UserBuyings { get; }
        public DelegateCommand GetChange { get; }
        public int Credit { get; }
        public ReadOnlyObservableCollection<MoneyVM> AutomataBank { get; }
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

    public class MoneyVM
    {
        private MoneyStack ms;

        public MoneyVM(MoneyStack ms)
        {
            this.ms = ms;
        }

        public Visibility IsInsertVisible { get; }
        public DelegateCommand InsertCommand { get; }
        public string Name { get; }
        public int Amount { get; }
    }
}
