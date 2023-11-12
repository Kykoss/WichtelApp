using System.Net.Mail;
using System.Net;

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
    }
}
