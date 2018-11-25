namespace FastFoodWorkshop.Middleware
{
    using Constants;
    using Models;
    using Microsoft.AspNetCore.Identity;
    using System.Linq;
    using Service.Contracts;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;

    public class SeedAdminAndRolesMiddleware
    {
        private readonly RequestDelegate next;

        public SeedAdminAndRolesMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

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

            var user = userManager.Users.FirstOrDefault(x => x.UserName == StringConstants.ManagerUsername);

            if (user == null)
            {
                  user =  userService.CreateManager(
                        StringConstants.ManagerFirstName,
                        StringConstants.ManagerLastName,
                        StringConstants.ManagerUsername,
                        StringConstants.ManagerBirthDate,
                        StringConstants.ManagerAddress);

                await userManager.CreateAsync(user, StringConstants.ManagerPassword);
                await userManager.AddToRoleAsync(user, StringConstants.ManagerRole);
            }

            await this.next(context);
        }
    }
}
