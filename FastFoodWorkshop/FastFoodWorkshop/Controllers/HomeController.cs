namespace FastFoodWorkshop.Controllers
{
    using ServiceModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;

    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return this.View();
        }


        public IActionResult WhoAreWe()
        {
            return this.View();
        }

        public IActionResult ContactsPage()
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
