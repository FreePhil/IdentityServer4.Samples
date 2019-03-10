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
        
        public EmailSender(IOptions<EmailSetting> emailSettingOptions)
        {
            emailSetting = emailSettingOptions.Value;
        }
        
        public Task SendEmailAsync(string recipientEmail, string subject, string htmlMessage)
        {
            try
            {
                // Credentials
                var emailSecret = new NetworkCredential(emailSetting.UserName, emailSetting.Password);

                // Mail message
                var mail = new MailMessage()
                {
                    From = new MailAddress(emailSetting.SenderEmail, emailSetting.SenderName),
                    Subject = subject,
                    Body = htmlMessage,
                    IsBodyHtml = true
                };

                mail.To.Add(new MailAddress(recipientEmail));
                var client = new SmtpClient()
                {
                    Host = emailSetting.Server,
                    Port = emailSetting.Port,
                    Credentials = emailSecret,
                    EnableSsl = true
                };
                
                return client.SendMailAsync(mail);
            }
            catch (Exception ex)
            {
                // TODO: handle exception
                throw new InvalidOperationException(ex.Message);
            }
        }
    }
}