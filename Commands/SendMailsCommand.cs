using System;
using System.Windows;
using System.Windows.Input;
using WichtelApp.Helper;

namespace WichtelApp.Commands
{
    public class SendMailsCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter) => true;

        public void Execute(object? parameter)
        {
            //MailHelper.SendTombolaResult(TombolaHelper.GetWichtelDrawing(ParticipantHelper.GetParticipants()));
        }
    }
}
