using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            var errorsInDraw = new List<int> ();
            var participants = ParticipantHelper.GetParticipants();
            var logFilePath = @"C:\temp\WichtelTombolaTest.log";

            if (File.Exists(logFilePath))
            {
                File.Delete(logFilePath);
            }

            for (int i = 1; i <= 10000; i++)
            {
                var results = TombolaHelper.GetWichtelDrawing(participants);
                var message = $"Draw {i} out of 10000:\n\n";

                foreach (var draw in results)
                {
                    message += $"{draw.Key.FirstName} => {draw.Value.FirstName}\n";
                }

                using (var sw = new StreamWriter(logFilePath, true))
                {
                    sw.WriteLine($"{message}\n\n");
                }

                if (!TombolaHelper.IsTombolaResultOk(participants, results))
                {
                    errorsInDraw.Add(i);
                }
            }

            if (errorsInDraw.Any())
            {
                using (var sw = new StreamWriter(@"C:\temp\WichtelTombolaTestErrors.log", true))
                {
                    foreach (var errorIndex in errorsInDraw)
                    {
                        sw .WriteLine(errorIndex);
                    }
                }
                MessageBox.Show("Errors found. Please check the logs!");
            }
            else
            {
                MessageBox.Show("No errors found!");
            }
        }
    }
}
