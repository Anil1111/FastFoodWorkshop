namespace FastFoodWorkshop.Middleware
{
    using Common.StringConstants;
    using Models;
    using Microsoft.AspNetCore.Identity;
    using System.Linq;
    using Service.Contracts;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Configuration;

    public class SeedAdminAndRolesMiddleware
    {
        private readonly RequestDelegate next;

        public SeedAdminAndRolesMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            this.next = next;
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public async Task InvokeAsync(
            HttpContext context,
            UserManager<FastFoodUser> userManager,
            RoleManager<IdentityRole<int>> roleManager,
            IUserService userService)
        {

            if(!roleManager.RoleExistsAsync(CommonStrings.ManagerRole).Result)
            {
                await roleManager.CreateAsync(new IdentityRole<int>(CommonStrings.ManagerRole));
            }
            if (!roleManager.RoleExistsAsync(CommonStrings.EmployeeRole).Result)
            {
                await roleManager.CreateAsync(new IdentityRole<int>(CommonStrings.EmployeeRole));
            }
            if (!roleManager.RoleExistsAsync(CommonStrings.UserRole).Result)
            {
                await roleManager.CreateAsync(new IdentityRole<int>(CommonStrings.UserRole));
            }
            var user = userManager.Users.FirstOrDefault(x => x.UserName == Configuration[Security.AdminInfoManagerName]);

            if (user == null)
            {
                user = userService.CreateManager(
                      Configuration[Security.AdminInfoManagerFirstName],
                      Configuration[Security.AdminInfoManagerLastName],
                      Configuration[Security.AdminInfoManagerName],
                      Configuration[Security.AdminInfoManagerBirthDate],
                      Configuration[Security.AdminInfoManagerAddress],
                      Configuration[Security.AdminInfoManagerEmail]);

                await userManager.CreateAsync(user, Configuration[Security.AdminInfoManagerPassword]);
                await userManager.AddToRoleAsync(user, CommonStrings.ManagerRole);
            }

            await this.next(context);
        }
    }
}
