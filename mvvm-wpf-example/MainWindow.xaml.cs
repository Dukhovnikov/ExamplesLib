using System.Windows;
using System.Windows.Markup;

namespace mvvm_wpf_example
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IComponentConnector
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }
}
