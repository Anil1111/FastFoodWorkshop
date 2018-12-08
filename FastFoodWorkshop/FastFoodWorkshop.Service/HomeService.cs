namespace FastFoodWorkshop.Service
{
    using AutoMapper;
    using Data;
    using Models;
    using Service.Contracts;
    using ServiceModels.Home;
    using System.IO;
    using System.Threading.Tasks;

    public class HomeService : IHomeService
    {
        private readonly IRepository<ApplicantCV> applicantRepository;
        private readonly IMapper mapper;

        public HomeService(IRepository<ApplicantCV> applicantRepository, IMapper mapper)
        {
            this.mapper = mapper;
            this.applicantRepository = applicantRepository;
        }

        public async Task AddApplicantCv(ApplicantCvInputModel inputModel)
        {
            var applicantCv = this.mapper.Map<ApplicantCV>(inputModel);

            using (var memoryStream = new MemoryStream())
            {
                await inputModel.Picture.CopyToAsync(memoryStream);
                applicantCv.Picture = memoryStream.ToArray();
            }

            await this.applicantRepository.AddAsync(applicantCv);

            await this.applicantRepository.SaveChangesAsync();
        }
    }
}
