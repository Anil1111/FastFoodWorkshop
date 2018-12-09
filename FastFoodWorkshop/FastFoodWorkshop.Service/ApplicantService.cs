namespace FastFoodWorkshop.Service
{
    using AutoMapper;
    using Data;
    using Models;
    using Service.Contracts;
    using ServiceModels.Applicant;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    public class ApplicantService : IApplicantService
    {
        private readonly IRepository<Education> educationRepository;
        private readonly IRepository<Job> jobRepository;
        private readonly IRepository<ApplicantCV> applicantRepository;
        private readonly IMapper mapper;

        public ApplicantService
            (IRepository<ApplicantCV> applicantRepository, 
             IMapper mapper,
             IRepository<Job> jobRepository,
             IRepository<Education> educationRepository)
        {
            this.mapper = mapper;
            this.applicantRepository = applicantRepository;
            this.jobRepository = jobRepository;
            this.educationRepository = educationRepository;
        }

        public async Task<int> AddApplicantCv(ApplicantCvInputModel inputModel)
        {
            var applicantCv = this.mapper.Map<ApplicantCV>(inputModel);

            if (inputModel.Picture != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await inputModel.Picture.CopyToAsync(memoryStream);
                    applicantCv.Picture = memoryStream.ToArray();
                }
            }

            await this.applicantRepository.AddAsync(applicantCv);

            return await this.applicantRepository.SaveChangesAsync();
        }

        public async Task<int> AddApplicantJob(JobInputModel inputModel)
        {
            var currentApplicant = this.applicantRepository.All().LastOrDefault();
            var job = this.mapper.Map<Job>(inputModel);

            if (currentApplicant != null)
            {
                job.ApplicantCVId = currentApplicant.Id;
            }

            await this.jobRepository.AddAsync(job);

            return await this.jobRepository.SaveChangesAsync();
        }

        public async Task<int> AddApplicantEducation(EducationInputModel inputModel)
        {
            var currentApplicant = this.applicantRepository.All().LastOrDefault();
            var education = this.mapper.Map<Education>(inputModel);

            if (currentApplicant != null)
            {
                education.ApplicantCVId = currentApplicant.Id;
            }

            await this.educationRepository.AddAsync(education);

            return await this.educationRepository.SaveChangesAsync();
        }
    }
}
