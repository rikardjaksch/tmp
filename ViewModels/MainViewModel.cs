using System.Windows.Input;
using wpf_windsor.Views;

namespace wpf_windsor.ViewModels
{
    public class MainViewModel : IViewModel
    {
        private readonly IViewFactory viewFactory;
        private ICommand launchCommand;
        
        public MainViewModel(IViewFactory viewFactory)
        {
            this.viewFactory = viewFactory;
        }

        public ICommand Launch
        {
            get { return launchCommand ?? (launchCommand = new DelegateCommand(ShowSecondWindow)); }
            set { launchCommand = value; }
        }

        private void ShowSecondWindow()
        {
            var view = viewFactory.CreateView<ISecondView>();
            view.Show();
        }
    }
}
