namespace FastFoodWorkshop.Controllers
{
    using ServiceModels;
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;

    public class BaseController : Controller
    {
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
