using System.Net.Mail;
using System.Net;
using System.Collections.Generic;
using System.IO;
using System;
using System.Windows;

namespace WichtelApp.Helper
{
    public static class MailHelper
    {
        private static MailAddress FromAdress => new MailAddress("wichtelschmichtel@gmx.de");

        public static void SendTestMail()
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = MailHelper.FromAdress;
            mailMessage.To.Add("robin.olde.meule1997@gmail.com");
            mailMessage.Subject = "Test Email Wichteln";
            mailMessage.Body = "Hallo Robert ich bin es nochmal!";

            MailHelper.SendSMTPEmail(mailMessage);
        }

        private static void SendSMTPEmail(MailMessage message)
        {
            using (var client = new SmtpClient())
            {
                client.Host = "mail.gmx.net";
                client.Port = 587;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("wichtelschmichtel@gmx.de", CredentialHelper.Passwort);
                client.EnableSsl = true;

                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                client.Send(message);
            }
        }

        public static void SendTombolaResult(Dictionary<Wichtel, Wichtel> tombolaResult)
        {
            const string failSafeFilePath = @"C:\temp\WichtelFailSafe.log";

            if (tombolaResult == null || tombolaResult.Count == 0)
            {
                throw new ArgumentException("Invalid Tombola Result!");
            }

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

            MessageBox.Show("Sieht gut aus!");
        }
    }
}
