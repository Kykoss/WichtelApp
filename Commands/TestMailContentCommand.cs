using System;
using System.IO;
using System.Windows.Input;
using WichtelApp.Helper;

namespace WichtelApp.Commands
{
    public class TestMailContentCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter) => true;

        public void Execute(object? parameter)
        {
            var tombolaResults = TombolaHelper.GetWichtelDrawing(ParticipantHelper.GetParticipants());

            foreach (var result in tombolaResults)
            {
                var mailMessage = MailHelper.GetMailMessage(result);

                using (var sw = new StreamWriter($@"C:\Temp\TestMailBody_{result.Key.FirstName}.log"))
                {
                    sw.WriteLine(mailMessage.Body);
                }
            }
        }
    }
}
