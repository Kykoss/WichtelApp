using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WichtelApp.Helper
{
    public static class RolloutHelper
    {
        private const string failSafeFilePath = @"C:\temp\WichtelFailSafe.log";

        public static void SendTombolaResult(Dictionary<Wichtel, Wichtel> tombolaResult, bool debug = true)
        {
            RolloutHelper.DoubleCheckTombolaResults(tombolaResult);
            RolloutHelper.CreateAndValidateFailSafe(tombolaResult);
            RolloutHelper.SendResultsToParticipants(tombolaResult);
        }

        public static void DoubleCheckTombolaResults(Dictionary<Wichtel, Wichtel> tombolaResult)
        {
            if (tombolaResult == null || tombolaResult.Count == 0)
            {
                throw new ArgumentException("Invalid Tombola Result!");
            }

            // Double check if the tombola result looks ok (although we kinda mocked the participant list)
            if (!TombolaHelper.IsTombolaResultOk(tombolaResult.Keys.ToList(), tombolaResult))
            {
                throw new ArgumentException("Tombola Result check failed!");
            }
        }

        public static void CreateAndValidateFailSafe(Dictionary<Wichtel, Wichtel> tombolaResult)
        {
            // Write the results to the failsafe file
            using (var sw = new StreamWriter(failSafeFilePath))
            {
                sw.WriteLine("Gifter => Receiver\n");
                foreach (var draw in tombolaResult)
                {
                    sw.WriteLine($"{draw.Key.FirstName} => {draw.Value.FirstName}");
                }
            }

            // Do NOT send the result until it is garuanteed that the failsafe file has bee generated!
            if (!File.Exists(failSafeFilePath))
            {
                throw new FileNotFoundException($"The fail safe filde could not be found ({failSafeFilePath})!");
            }

            string[] contentLines;
            using (var sr = new StreamReader(failSafeFilePath))
            {
                contentLines = sr.ReadToEnd().Split("\r");
            }

            if (contentLines.Length < 9)
            {
                throw new Exception("Something seems to be off with the failsafe file");
            }
        }

        public static void SendResultsToParticipants(Dictionary<Wichtel, Wichtel> tombolaResult)
        {
            foreach (var draw in tombolaResult)
            {
                MailHelper.SendSMTPEmail(MailHelper.GetMailMessage(draw));
            }
        }
    }
}
