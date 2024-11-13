using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using WichtelApp.Helper;

namespace WichtelApp.Commands
{
    public class TestMailBodyCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter) => true;

        public void Execute(object? parameter)
        {
            var receiver = new Wichtel("Ingo", "Pimmelnase", "testmail@mail.com");
            var mail = MailHelper.GetMailMessage(new(new Wichtel("Robin", "Olde Meule", "testmail@mail.com"), receiver));

            MessageBox.Show(mail.Body);
        }
    }
}
