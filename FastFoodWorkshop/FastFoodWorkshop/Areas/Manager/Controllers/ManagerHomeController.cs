namespace FastFoodWorkshop.Areas.Manager.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class ManagerHomeController : ManagerBaseController
    {
        public ManagerHomeController()
        {

        }

        public IActionResult Index()
        {
            return this.View();
        }
    }
}
