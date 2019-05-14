// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [Route("identity")]
    public class IdentityController : ControllerBase
    {
        private ApplicationDbContext context;

        public IdentityController(ApplicationDbContext context)
        {
            this.context = context;
        }
        
        public async Task<ActionResult> Get()
        {
            var id = User.FindFirst(ClaimTypes.Role).Value;
            var user = await context.Users.SingleAsync(u => u.Id == id);
            
            return new JsonResult( new { Name = $"{user.LastName}{user.FirstName}", Role = user.Role });
        }
    }
}