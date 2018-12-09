namespace FastFoodWorkshop.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        [AllowAnonymous]
        [RequireHttps]
        public IActionResult Index()
        {
            return this.View();
        }

        [AllowAnonymous]
        [RequireHttps]
        public IActionResult WhoAreWe()
        {
            return this.View();
        }

        [AllowAnonymous]
        [RequireHttps]
        public IActionResult ContactsPage()
        {
            return this.View();
        }
    }
}
