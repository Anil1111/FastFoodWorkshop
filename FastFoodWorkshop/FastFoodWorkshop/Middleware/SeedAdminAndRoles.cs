namespace FastFoodWorkshop.Middleware
{
    using Models;
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Service;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;

    public class SeedAdminAndRoles
    {
        private readonly RequestDelegate next;

        public SeedAdminAndRoles(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task SeedAdminAndRolesAsync(
            HttpContext context,
            UserManager<FastFoodUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {


            await this.next(context);
        }
    }
}
