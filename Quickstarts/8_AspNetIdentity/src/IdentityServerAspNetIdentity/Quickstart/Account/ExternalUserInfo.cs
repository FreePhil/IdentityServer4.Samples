using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;
using IdentityServerAspNetIdentity.Models;

namespace IdentityServerAspNetIdentity.Quickstart.Account
{
    public class ExternalUserInfo
    {
        public ApplicationUser  User { get; set; }
        public string Provider { get; set; }
        public string ProviderUserId { get; set; }
        public IEnumerable<Claim> Claims { get; set; }
        
    }
}