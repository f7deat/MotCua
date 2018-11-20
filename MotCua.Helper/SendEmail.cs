using System;
using System.Net;
using System.Net.Mail;

namespace MotCua.Helper
{
    public class SendEmail
    {
        public static int Send(string receiver, string subject, string message)
        {
            try
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                //If you need to authenticate
                client.Credentials = new NetworkCredential("tdlong195@gmail.com", "Tranlongh");

                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("tdlong195@gmail.com");
                mailMessage.To.Add(receiver);
                mailMessage.Subject = subject;
                mailMessage.Body = message;
                mailMessage.IsBodyHtml = true;

                client.Send(mailMessage);
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
        }
    }
}
