using System;
using System.Windows.Input;

namespace WichtelApp.Commands
{
    public class SendTestMailCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter) => true;

        public void Execute(object? parameter)
        {
            throw new NotImplementedException();
        }
    }
}
