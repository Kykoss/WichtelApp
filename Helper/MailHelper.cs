using System.Net.Mail;
using System.Net;
using System.Collections.Generic;

namespace WichtelApp.Helper
{
    public static class MailHelper
    {
        private static MailAddress FromAdress => new MailAddress("wichtelschmichtel@gmx.de");

        public static MailMessage GetMailMessage(KeyValuePair<Wichtel, Wichtel> draw)
        {
            var gifter = draw.Key;
            var receiver = draw.Value;
            var attachments = new Attachment($"C:\\Users\\Sir Robert\\source\\repos\\WichtelApp\\Resources\\{receiver.FirstName}.jpeg") { ContentId = "WichtelImage"};

            var mailMessage = new MailMessage();
            mailMessage.From = MailHelper.FromAdress;
            mailMessage.To.Add(gifter.Email);
            mailMessage.Subject = "Test Email Wichteln";
            mailMessage.Attachments.Add(attachments);
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = $"<html><body><img src=\"cid:WichtelImage\"><br><br>{receiver.BackGroundStory}</body></html>";

            return mailMessage;
        }

        public static void SendTestMails()
        {
            var mockedDraw = new KeyValuePair<Wichtel, Wichtel>(new Wichtel("Robin", "Olde Meule", "robin.olde.meule1997@gmail.com"), new Wichtel("Lukas", "Empty", string.Empty));
            MailHelper.SendSMTPEmail(MailHelper.GetMailMessage(mockedDraw));

            mockedDraw = new KeyValuePair<Wichtel, Wichtel>(new Wichtel("Robin", "Olde Meule", "robin.olde.meule1997@gmail.com"), new Wichtel("Jan", "Empty", string.Empty));
            MailHelper.SendSMTPEmail(MailHelper.GetMailMessage(mockedDraw));

            mockedDraw = new KeyValuePair<Wichtel, Wichtel>(new Wichtel("Robin", "Olde Meule", "robin.olde.meule1997@gmail.com"), new Wichtel("Leon", "Empty", string.Empty));
            MailHelper.SendSMTPEmail(MailHelper.GetMailMessage(mockedDraw));

            mockedDraw = new KeyValuePair<Wichtel, Wichtel>(new Wichtel("Robin", "Olde Meule", "robin.olde.meule1997@gmail.com"), new Wichtel("Moritz", "Empty", string.Empty));
            MailHelper.SendSMTPEmail(MailHelper.GetMailMessage(mockedDraw));

            mockedDraw = new KeyValuePair<Wichtel, Wichtel>(new Wichtel("Robin", "Olde Meule", "robin.olde.meule1997@gmail.com"), new Wichtel("Jannik", "Empty", string.Empty));
            MailHelper.SendSMTPEmail(MailHelper.GetMailMessage(mockedDraw));

            mockedDraw = new KeyValuePair<Wichtel, Wichtel>(new Wichtel("Robin", "Olde Meule", "robin.olde.meule1997@gmail.com"), new Wichtel("Kara", "Empty", string.Empty));
            MailHelper.SendSMTPEmail(MailHelper.GetMailMessage(mockedDraw));

            mockedDraw = new KeyValuePair<Wichtel, Wichtel>(new Wichtel("Robin", "Olde Meule", "robin.olde.meule1997@gmail.com"), new Wichtel("Ingo", "Empty", string.Empty));
            MailHelper.SendSMTPEmail(MailHelper.GetMailMessage(mockedDraw));

            mockedDraw = new KeyValuePair<Wichtel, Wichtel>(new Wichtel("Robin", "Olde Meule", "robin.olde.meule1997@gmail.com"), new Wichtel("Robin", "Empty", string.Empty));
            MailHelper.SendSMTPEmail(MailHelper.GetMailMessage(mockedDraw));
        }

        public static void SendSMTPEmail(MailMessage message)
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
