using System;
using System.Windows.Input;
using WichtelApp.Helper;

namespace WichtelApp.Commands
{
    public class SendTestMailCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter) => true;

        public void Execute(object? parameter) => MailHelper.SendTestMail();
    }
}
