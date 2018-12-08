namespace FastFoodWorkshop.Service.Contracts
{
    using ServiceModels.Home;
    using System.Threading.Tasks;

    public interface IHomeService
    {
        Task AddApplicantCv(ApplicantCvInputModel inputModel);
    }
}
