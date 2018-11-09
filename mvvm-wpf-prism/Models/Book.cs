using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvvm_wpf_prism.Models
{
    public class Book : BindableBase
    {
        private string _author;
        public string Author
        {
            get { return _author; }
            set
            {
                _author = value;
                RaisePropertyChanged("Author");
            }
        }

        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                RaisePropertyChanged("Title");
            }
        }

        private DateTime _year;
        public DateTime Year
        {
            get { return _year; }
            set
            {
                _year = value;
                RaisePropertyChanged("Year");
            }
        }

        private string _sn;
        public string SN
        {
            get { return _sn; }
            set
            {
                _sn = value;
                RaisePropertyChanged("SN");
            }
        }

        private int _count;
        public int Count
        {
            get { return _count; }
            set
            {
                _count = value;
                RaisePropertyChanged("Count");
            }
        }
    }
}
