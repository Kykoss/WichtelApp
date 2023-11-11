using System;
using System.Windows;
using System.Windows.Input;

namespace WichtelApp.Commands
{
    public class SendMailsCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter) => true;

        public void Execute(object? parameter)
        {
            MessageBox.Show("Oh Junge jetzt gehts los!");
        }
    }
}
