using System.Windows;
using wpf_windsor.ViewModels;
using wpf_windsor.Views;

namespace wpf_windsor
{
    public partial class MainWindow : Window, IMainView
    {
        public MainWindow(MainViewModel viewModel)
        {
            InitializeComponent();
        }
    }
}
