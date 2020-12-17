using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace MVC_Identity.Services
{
    public class EmailService : IEmailService
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            // TODO complete the email sending

            //SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 25);

            //smtpClient.Credentials = new System.Net.NetworkCredential("forumdotnet7@gmail.com", "Aa!123456");
            //smtpClient.UseDefaultCredentials = true;
            //smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            //smtpClient.EnableSsl = true;
            //MailMessage mail = new MailMessage();

            ////Setting From , To and CC
            //mail.From = new MailAddress("forumdotnet7@gmail.com", "Forum DotNet");
            //mail.To.Add(new MailAddress(email));

            //// TODO add ourselves as cc for debug and then delete
            //// mail.CC.Add(new MailAddress("forumdotnet7@gmail.com"));

            //// add subject and message

            //mail.Subject = subject;
            //mail.SubjectEncoding = System.Text.Encoding.UTF8;

            //mail.Body = message;
            //mail.BodyEncoding = System.Text.Encoding.UTF8;

            //smtpClient.Send(mail);
            secondTrySend(email, subject, message);
            return Task.CompletedTask;
        }

        protected void secondTrySend(string email, string subject, string message)
        {

            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
            mail.To.Add(email);
            mail.From = new MailAddress("forumdotnet7@gmail.com", "Forum DotNet", System.Text.Encoding.UTF8);
            mail.Subject = subject;
            mail.SubjectEncoding = System.Text.Encoding.UTF8;
            
            mail.Body = message;
            mail.BodyEncoding = System.Text.Encoding.UTF8;
            mail.IsBodyHtml = true;

            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential("forumdotnet7@gmail.com", "Aa!123456");
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            
            try
            {
                client.Send(mail);
                //Page.RegisterStartupScript("UserMsg", "<script>alert('Successfully Send...');if(alert){ window.location='SendMail.aspx';}</script>");
            }
            catch (Exception ex)
            {
                Exception ex2 = ex;
                string errorMessage = string.Empty;
                throw ex;
            }
        }
    }
}
