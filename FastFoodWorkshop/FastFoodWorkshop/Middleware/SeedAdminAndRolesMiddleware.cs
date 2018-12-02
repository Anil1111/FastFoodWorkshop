namespace FastFoodWorkshop.Middleware
{
    using Constants;
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

            if(!roleManager.RoleExistsAsync(StringConstants.ManagerRole).Result)
            {
                await roleManager.CreateAsync(new IdentityRole<int>(StringConstants.ManagerRole));
            }
            if (!roleManager.RoleExistsAsync(StringConstants.EmployeeRole).Result)
            {
                await roleManager.CreateAsync(new IdentityRole<int>(StringConstants.EmployeeRole));
            }
            if (!roleManager.RoleExistsAsync(StringConstants.UserRole).Result)
            {
                await roleManager.CreateAsync(new IdentityRole<int>(StringConstants.UserRole));
            }
            var user = userManager.Users.FirstOrDefault(x => x.UserName == Configuration["AdminInfo:ManagerName"]);

            if (user == null)
            {
                user = userService.CreateManager(
                      Configuration["AdminInfo:ManagerFirstName"],
                      Configuration["AdminInfo:ManagerLastName"],
                      Configuration["AdminInfo:ManagerName"],
                      Configuration["AdminInfo:ManagerBirthDate"],
                      Configuration["AdminInfo:ManagerAddress"],
                      Configuration["AdminInfo:ManagerEmail"]);

                await userManager.CreateAsync(user, Configuration["AdminInfo:ManagerPassword"]);
                await userManager.AddToRoleAsync(user, StringConstants.ManagerRole);
            }

            await this.next(context);
        }
    }
}
