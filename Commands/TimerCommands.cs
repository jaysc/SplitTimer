using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SplitTimer.ViewModels;

namespace SplitTimer.Commands
{
    internal class TextOnClickCommand : ICommand
    {
        public TextOnClickCommand(TimerViewModel viewModel)
        {
            myTimerViewModel = viewModel;
        }

        private TimerViewModel myTimerViewModel;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return myTimerViewModel.CanUpdate;
        }

        public void Execute(object parameter)
        {
            myTimerViewModel.TimerToggle();
        }
    }
}
