// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;

namespace IdentityServer
{
    public static class Config
    {
        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "alice",
                    Password = "password",

                    Claims = new []
                    {
                        new Claim("name", "Alice"),
                        new Claim("website", "https://alice.com")
                    }
                },
                new TestUser
                {
                    SubjectId = "2",
                    Username = "bob",
                    Password = "password",

                    Claims = new []
                    {
                        new Claim("name", "Bob"),
                        new Claim("website", "https://bob.com")
                    }
                }
            };
        }

        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
                new IdentityResource
                {
                    DisplayName = "EDU scope",
                    Name = "edu",
                    Description = "Show school member",
                    UserClaims = new List<string> {"a", "b"},
                }
            };
        }

        public static IEnumerable<ApiResource> GetApis()
        {
            return new List<ApiResource>
            {
                new ApiResource("api", "My API")
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "client",

                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },

                    // scopes that client has access to
                    AllowedScopes = { "api1" }
                },
                // resource owner password grant client
                new Client
                {
                    ClientId = "ro.client",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,

                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = { "api" }
                },
                // OpenID Connect hybrid flow client (MVC)
                new Client
                {
                    ClientId = "mvc",
                    ClientName = "MVC Client",
<<<<<<< HEAD:Quickstarts/5_HybridFlowAuthenticationWithApiAccess/src/QuickstartIdentityServer/Config.cs
                    AllowedGrantTypes = GrantTypes.HybridAndClientCredentials,
                   
                    ClientSecrets = 
=======
                    AllowedGrantTypes = GrantTypes.Hybrid,

                    ClientSecrets =
>>>>>>> 213acca612b0e78811f339e5fb846de2e747ce91:Quickstarts/5_HybridFlowAuthenticationWithApiAccess/src/IdentityServer/Config.cs
                    {
                        new Secret("secret".Sha256())
                    },

                    RedirectUris           = { "http://localhost:5002/signin-oidc" },
                    PostLogoutRedirectUris = { "http://localhost:5002/signout-callback-oidc" },
<<<<<<< HEAD:Quickstarts/5_HybridFlowAuthenticationWithApiAccess/src/QuickstartIdentityServer/Config.cs
                    
                    AllowedScopes = 
=======

                    AllowedScopes =
>>>>>>> 213acca612b0e78811f339e5fb846de2e747ce91:Quickstarts/5_HybridFlowAuthenticationWithApiAccess/src/IdentityServer/Config.cs
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "edu",
                        "api"
                    },
<<<<<<< HEAD:Quickstarts/5_HybridFlowAuthenticationWithApiAccess/src/QuickstartIdentityServer/Config.cs
                    AllowOfflineAccess = true, 
                    AlwaysSendClientClaims = true,
                    AlwaysIncludeUserClaimsInIdToken = true
                }
            };
        }

        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "alice",
                    Password = "password",

                    Claims = new List<Claim>
                    {
                        new Claim("name", "Alice"),
                        new Claim("website", "https://alice.com"),
                        new Claim("email", "alice@gmail.com"),
                        new Claim("a", "alice-aaa"),
                    }
                },
                new TestUser
                {
                    SubjectId = "2",
                    Username = "bob",
                    Password = "password",

                    Claims = new List<Claim>
                    {
                        new Claim("name", "Bob"),
                        new Claim("website", "https://bob.com")
                    }
=======

                    AllowOfflineAccess = true
>>>>>>> 213acca612b0e78811f339e5fb846de2e747ce91:Quickstarts/5_HybridFlowAuthenticationWithApiAccess/src/IdentityServer/Config.cs
                }
            };
        }
    }
}