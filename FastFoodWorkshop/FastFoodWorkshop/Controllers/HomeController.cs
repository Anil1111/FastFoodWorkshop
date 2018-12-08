namespace FastFoodWorkshop.Controllers
{
    using ServiceModels;
    using Service.Contracts;
    using ServiceModels.Home;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;
    using AutoMapper;
    using FastFoodWorkshop.Models;
    using System.Threading.Tasks;

    public class HomeController : BaseController
    {
        private readonly IHomeService homeService;
        private readonly IMapper mapper;

        public HomeController(IHomeService homeService, IMapper mapper)
        {
            this.mapper = mapper;
            this.homeService = homeService;
        }

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

        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> JoinUs(ApplicantCvInputModel inputModel)
        {
            if (ModelState.IsValid)
            {
                await this.homeService.AddApplicantCv(inputModel);
            }

            return this.Redirect("/");
        }

        [RequireHttps]
        [AllowAnonymous]
        public IActionResult AddJob()
        {
            return this.View();
        }

        [RequireHttps]
        [AllowAnonymous]
        public IActionResult AddEducation()
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
