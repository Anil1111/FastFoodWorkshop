namespace FastFoodWorkshop.Controllers
{
    using FastFoodWorkshop.ServiceModels.ViewModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;

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

        [AllowAnonymous]
        [RequireHttps]
        public IActionResult JoinUs()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
