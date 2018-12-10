namespace FastFoodWorkshop.Controllers
{
    using AutoMapper;
    using Common.StringConstants;
    using Service.Contracts;
    using ServiceModels.Applicant;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using System;
    using Microsoft.AspNetCore.Http;

    public class ApplicantController : BaseController
    {
        private readonly IApplicantService applicantService;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        private ISession session => httpContextAccessor.HttpContext.Session;
        private readonly string joinUsSessionValue;

        public ApplicantController(
            IApplicantService applicantService, 
            IMapper mapper,
            IHttpContextAccessor httpContextAccessor)
        {
            this.mapper = mapper;
            this.applicantService = applicantService;
            this.httpContextAccessor = httpContextAccessor;
            this.joinUsSessionValue = Security.SessionValueJoinUsForm;
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
                    session.SetString(Security.SessionKeyJoinUsForm, this.joinUsSessionValue);
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
            if (session.GetString(Security.SessionKeyJoinUsForm) != joinUsSessionValue)
            {
                //TODO Add view with a redirect message
                return this.Redirect(ViewNames.JoinUs);
            }

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
            if (session.GetString(Security.SessionKeyJoinUsForm) != joinUsSessionValue)
            {
                //TODO Add view with a redirect message
                return this.Redirect(ViewNames.JoinUs);
            }

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
            session.Remove(Security.SessionKeyJoinUsForm);
            return this.View();
        }
    }
}
