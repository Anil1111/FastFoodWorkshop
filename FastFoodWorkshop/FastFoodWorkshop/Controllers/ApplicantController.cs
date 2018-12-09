namespace FastFoodWorkshop.Controllers
{
    using AutoMapper;
    using Common;
    using Service.Contracts;
    using ServiceModels.Applicant;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using System;

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
                try
                {
                    await this.applicantService.AddApplicantCv(inputModel);
                    return this.Redirect(ViewNames.AddJob);
                }
                catch (Exception)
                {
                    return StatusCode(500, ErrorMessages.InternalServerError);
                }
            }

            return this.JoinUs();
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
            if (ModelState.IsValid)
            {
                try
                {
                    await this.applicantService.AddApplicantJob(jobInputModel);
                    return this.View(ViewNames.JobSuccess);
                }
                catch (Exception)
                {
                    return StatusCode(500, ErrorMessages.InternalServerError);
                }
            }

            return AddJob();
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
            if (ModelState.IsValid)
            {
                try
                {
                    await this.applicantService.AddApplicantEducation(inputModel);
                    return this.View(ViewNames.EducationSuccess);
                }
                catch (Exception)
                {
                    return StatusCode(500, ErrorMessages.InternalServerError);
                }
            }

            return AddEducation();
        }

        [RequireHttps]
        [AllowAnonymous]
        public IActionResult ApplicantSuccess()
        {
            return this.View();
        }
    }
}
