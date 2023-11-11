using System;
using System.IO;
using System.Windows;
using System.Windows.Input;
using WichtelApp.Helper;

namespace WichtelApp.Commands
{
    public class TestTombolaCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter) => true;

        public void Execute(object? parameter)
        {
            for (int i = 1; i <= 10000; i++)
            {
                var results = TombolaHelper.GetWichtelDrawing(ParticipantHelper.GetParticipants());
                var message = $"Draw {i} out of 10000:\n\n";

                foreach (var draw in results)
                {
                    message += $"{draw.Key.FirstName} => {draw.Value.FirstName}\n";
                }

                using (var sw = new StreamWriter(@"C:\temp\WichtelTombolaTest.log", true))
                {
                    sw.WriteLine($"{message}\n\n");
                }
            }
        }
    }
}
