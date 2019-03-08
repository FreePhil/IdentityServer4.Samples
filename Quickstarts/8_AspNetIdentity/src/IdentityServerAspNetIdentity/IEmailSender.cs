using System.Threading.Tasks;

namespace IdentityServerAspNetIdentity
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string recipientEmail, string subject, string htmlMessage);
    }
}