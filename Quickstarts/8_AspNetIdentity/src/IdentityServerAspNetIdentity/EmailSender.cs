using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;

namespace IdentityServerAspNetIdentity
{
    public class EmailSender: IEmailSender
    {
        private readonly EmailSetting emailSetting;
        
        public EmailSender(IOptions<EmailSetting> emailSetting)
        {
            emailSetting = emailSetting;
        }
        
        public Task SendEmailAsync(string recipientEmail, string subject, string htmlMessage)
        {
            try
            {
                // Credentials
                var credentials = new NetworkCredential(emailSetting.Sender, emailSetting.Password);

                // Mail message
                var mail = new MailMessage()
                {
                    From = new MailAddress(emailSetting.Sender, emailSetting.SenderName),
                    Subject = subject,
                    Body = htmlMessage,
                    IsBodyHtml = true
                };

                mail.To.Add(new MailAddress(recipientEmail));

                // Smtp client
                var client = new SmtpClient()
                {
                    Port = emailSetting.MailPort,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Host = emailSetting.MailServer,
                    EnableSsl = true,
                    Credentials = credentials
                };

                return client.SendMailAsync(mail);
            }
            catch (Exception ex)
            {
                // TODO: handle exception
                throw new InvalidOperationException(ex.Message);
            }

//            return Task.CompletedTask;
        }
    }
}