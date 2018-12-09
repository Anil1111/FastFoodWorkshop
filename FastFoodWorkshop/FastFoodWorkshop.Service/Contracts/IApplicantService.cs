namespace FastFoodWorkshop.Service.Contracts
{
    using ServiceModels.Applicant;
    using System.Threading.Tasks;

    public interface IApplicantService
    {
        Task<int> AddApplicantCv(ApplicantCvInputModel inputModel);

        Task<int> AddApplicantJob(JobInputModel inputModel);

        Task<int> AddApplicantEducation(EducationInputModel inputModel);
    }
}
