using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace wpf_windsor.ViewModels
{
    public class DelegateCommand : ICommand
    {
        private readonly Action executeMethod;
        private readonly Func<bool> canExecuteMethod;

        public DelegateCommand(Action executeMethod)
            : this(executeMethod, () => true)
        {

        }

        public DelegateCommand(Action executeMethod, Func<bool> canExecuteMethod)
        {
            this.executeMethod = executeMethod ?? throw new ArgumentNullException("executeMethod can not be null");
            this.canExecuteMethod = canExecuteMethod ?? throw new ArgumentNullException("canExecuteMethod can not be null");
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return CanExecute();
        }

        public bool CanExecute()
        {
            return canExecuteMethod();
        }

        public void Execute(object parameter)
        {
            Execute();
        }

        public void Execute()
        {
            executeMethod();
        }

        public void OnCanExecuteChanged()
        {
            CommandManager.InvalidateRequerySuggested();
        }
    }
}
