using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvvm_wpf_prism.ViewModels
{
    public class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            LibraryViewModel = new LibraryViewModel();
        }

        public LibraryViewModel LibraryViewModel { get; set; }
    }
}
