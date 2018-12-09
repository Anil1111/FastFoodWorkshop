namespace FastFoodWorkshop.Controllers
{
    using AutoMapper;
    using Service.Contracts;
    using ServiceModels.Applicant;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class ApplicantController : BaseController
    {

        private readonly IApplicantService applicantService;
        private readonly IMapper mapper;

        public ApplicantController(IApplicantService applicantService, IMapper mapper)
        {
            this.mapper = mapper;
            this.applicantService = applicantService;
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
                await this.applicantService.AddApplicantCv(inputModel);
                return this.Redirect("AddJob");
            }

            return JoinUs();
        }

        [RequireHttps]
        [AllowAnonymous]
        public IActionResult AddJob()
        {
            return this.View();
        }

        [RequireHttps]
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> AddJob(JobInputModel jobInputModel)
        {
            await this.applicantService.AddApplicantJob(jobInputModel);

            return this.View("JobSuccess");
        }

        [RequireHttps]
        [AllowAnonymous]
        public IActionResult AddEducation()
        {
            return this.View();
        }

        [RequireHttps]
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> AddEducation(EducationInputModel inputModel)
        {
            await this.applicantService.AddApplicantEducation(inputModel);

            return this.View("EducationSuccess");
        }

        [RequireHttps]
        [AllowAnonymous]
        public IActionResult ApplicantSuccess()
        {
            return this.View();
        }
    }
}
