using System.Net;
using System.Net.Mail;

namespace EmailService
{
    public class OtpCodeService
    {
        public static string EmailSend(string Email, string Subject, string Body)
        {
            string fromMail = "miyuranga@athugalacredit.com";
            string password = "Ah(m4Dq3+o3U8U";

            MailMessage message = new MailMessage();
            message.From = new MailAddress(fromMail);
            message.Subject = Subject;
            message.To.Add(new MailAddress(Email));
            message.Body = "<html><body>" + Body + "</body></html>";
            message.IsBodyHtml = true;

            using (var smtp = new SmtpClient("mail.athugalacredit.com", 465))
            {
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(fromMail, password);
                smtp.EnableSsl = true;

                try
                {
                    smtp.Send(message);
                    return "Success";
                }
                catch (SmtpException smtpEx)
                {
                    // Handle SMTP-specific exceptions
                    return "SMTP Error: " + smtpEx.Message;
                }
                catch (Exception ex)
                {
                    // Handle other exceptions
                    return "Error: " + ex.Message;
                }
            }
        }

    }
}
