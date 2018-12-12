namespace FastFoodWorkshop.Areas.Manager.Controllers
{
    using FastFoodWorkshop.Common.StringConstants;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [RequireHttps]
    [Area(CommonStrings.ManagerArea)]
    [Authorize(Roles = CommonStrings.ManagerRole)]
    public class ManagerBaseController : Controller
    {

    }
}
