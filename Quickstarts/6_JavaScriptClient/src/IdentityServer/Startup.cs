// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using System;
using IdentityModel;
using IdentityServer4;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace IdentityServer
{
    public class Startup
    {
        public IHostingEnvironment Environment { get; }

        public Startup(IHostingEnvironment environment)
        {
            Environment = environment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_2_2);

            var builder = services.AddIdentityServer(options =>
                {
                    options.PublicOrigin = "https://id.hle.com.tw";
                })
                .AddInMemoryIdentityResources(Config.GetIdentityResources())
                .AddInMemoryApiResources(Config.GetApis())
                .AddInMemoryClients(Config.GetClients())
                .AddTestUsers(Config.GetUsers());

            builder.AddDeveloperSigningCredential();
//            if (Environment.IsDevelopment())
//            {
//                builder.AddDeveloperSigningCredential();
//            }
//            else
//            {
//                throw new Exception("need to configure key material");
//            }

            services.AddAuthentication()
                .AddGoogle("Google", options =>
                {
                    options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;
                    options.ClientId = "252761815268-itp5jf1roc52kdqslpj82rrvenf9ppih.apps.googleusercontent.com";
                    options.ClientSecret = "M7JB7BvtRo4xKwvZT4W7Lyjh";
                })
                .AddOpenIdConnect("oidc", "OpenID Connect", options =>
                {
                    options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;
                    options.SignOutScheme = IdentityServerConstants.SignoutScheme;
                    options.SaveTokens = true;

                    options.Authority = "https://demo.identityserver.io/";
                    options.ClientId = "implicit";

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        NameClaimType = "name",
                        RoleClaimType = "role"
                    };
                })
                .AddOpenIdConnect("moe", "教育部 OIDC", options =>
                {
                    options.ClientId = "dd7acb893d2bf25f825c042b138bc769";
                    options.ClientSecret = "59b89617fe3448ada8d86792c77c13e1d5dcff9c52698dda109adc970504785b";
                    options.Authority = "https://oidc.tanet.edu.tw/";
                    options.CallbackPath = new PathString("/signin-moe");
                    options.ResponseType = "code";
                    options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;
                });;
        }

        public void Configure(IApplicationBuilder app)
        {
            if (Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseIdentityServer();

            app.UseMvcWithDefaultRoute();
        }
    }
}