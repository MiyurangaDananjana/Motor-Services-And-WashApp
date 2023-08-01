using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EmailService
{
    public class OtpCodeService
    {
        public static void EmailSend(string Email, string Subject, string Body)
        {
            string fromMail = "miyuranga.athugala@gmail.com";
            string password = "osrifjrflkkpscox";

            MailMessage message = new MailMessage();
            message.From = new MailAddress(fromMail);
            message.Subject = Subject;
            message.To.Add(new MailAddress(Email));
            message.Body = "<html><body>" + Body + "</body></html>";
            message.IsBodyHtml = true;
            var smtp = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(fromMail, password),
                EnableSsl = true
            };
            smtp.Send(message);
        }

    }
}
