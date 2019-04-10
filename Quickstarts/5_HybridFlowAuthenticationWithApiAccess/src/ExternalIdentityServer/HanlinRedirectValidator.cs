using System.Threading.Tasks;
using IdentityServer4.Models;
using IdentityServer4.Validation;

namespace ExternalIdentityServer
{
    public class HanlinRedirectValidator: IRedirectUriValidator
    {
        public Task<bool> IsPostLogoutRedirectUriValidAsync(string requestedUri, Client client)
        {
            return Task.FromResult(true);
        }

        public Task<bool> IsRedirectUriValidAsync(string requestedUri, Client client)
        {
            return Task.FromResult(true);
        }
    }
}