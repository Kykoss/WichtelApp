using System.Net.Mail;
using System.Net;
using System.Collections.Generic;
using System.IO;
using System;
using System.Windows;
using System.Linq;

namespace WichtelApp.Helper
{
    public static class MailHelper
    {
        private static MailAddress FromAdress => new MailAddress("wichtelschmichtel@gmx.de");

        public static MailMessage GetMailMessage(KeyValuePair<Wichtel, Wichtel> draw)
        {
            var gifter = draw.Key;
            var receiver = draw.Value;

            var mailMessage = new MailMessage();
            mailMessage.From = MailHelper.FromAdress;
            mailMessage.To.Add(gifter.Email);
            mailMessage.Subject = "Test Email Wichteln";
            mailMessage.Body = $"Hallo {gifter.FirstName},\n\nEs ist wieder soweit! Das diesjaehrige Wichteln des Vereins fuer Allzeit inkompetente dumme Spassten (AIDS e.V.) steht wieder an und Sie koennen stolz " +
                $"darauf sein ein Teil dieser tollen und hoffentlich einzigartigen Truppe zu sein!\n\nWie bereits angekuendigt, sollte es dieses Jahr ausgeschlossen sein, dass Sie den gleichen Partner wie im letzten Jahr bekommen.\n" +
                $"Falls dies dennoch der Fall sein sollte, bitte eben Bescheid geben. Dann wird die Logik fuer das naechste Jahr noch einmal ueberarbeitet!\n\n";

            if (receiver.LastName == "Kolthof")
            {
                mailMessage.Body += "Leider muss ich Ihnen untroestlicherweise mitteilen, dass sie dieses Jahr das schwarze Los gezogen haben...\nIhr diesjaehrige Wichtelpartner ist niemand niedertraechtigeres als Jannik Kolthof, " +
                    $"der wahre Zerstoerer von Habibibyte und vermutlich auch vieler weiterer Mikrokosmen dieser Erde.\n\nSie sind selbstverstaendlich weiterhin gerne eingeladen an der dies jaehrigen Weihnachtsfeier teilzunehmen, " +
                    $"aber Sie wissen genau so gut wie ich, dass Sie sich bereits auf ein zweites Weihnachten im Fruehling 2024 mit Herrn Kolthof freuen duerfen!";
            }
            else
            {
                mailMessage.Body += $"Dieses Jahr haben Sie die Ehre den oder die ehrenhafte {receiver.FirstName} {receiver.LastName} zu beschenken! Bitte suchen Sie ein passendes und freudeerweckendes Geschenk aus! " +
                    $"Ich bin mir sicher, dass diese Person es verdient hat!";
            }

            mailMessage.Body += "\n\nWeitere Informationen zu dem Budget und zu der diesjaehrigen Weihnachtsfeier folgen in den kommenden Wochen!";

            return mailMessage;
        }

        public static void SendTestMail()
        {
            var mockedDraw = new KeyValuePair<Wichtel, Wichtel>(new Wichtel("Robin", "Olde Meule", "robin.olde.meule1997@gmail.com"), new Wichtel("Lukas", "Wewel", string.Empty));

            MailHelper.SendSMTPEmail(MailHelper.GetMailMessage(mockedDraw));
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
