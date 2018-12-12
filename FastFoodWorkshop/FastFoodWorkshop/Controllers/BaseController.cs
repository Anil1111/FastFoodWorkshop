namespace FastFoodWorkshop.Controllers
{
    using Common.StringConstants;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [AllowAnonymous]
    [RequireHttps]
    public class BaseController : Controller
    {
        
    }
}
