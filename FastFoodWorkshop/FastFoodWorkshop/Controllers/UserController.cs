namespace FastFoodWorkshop.Controllers
{
    using System.Security.Claims;
    using Service.Contracts;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class UserController : BaseController
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        public async Task<IActionResult> MyProfile()
        {
            var user = this.User;
            var viewModel = await this.userService.GetUserDetailsAsync(user);

            return this.View(viewModel);
        }
    }
}
