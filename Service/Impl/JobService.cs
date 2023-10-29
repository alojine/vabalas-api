using vabalas_api.Controllers.Job.Dtos;
using vabalas_api.Enums;
using vabalas_api.Exceptions;
using vabalas_api.Models;
using vabalas_api.Repositories;
using vabalas_api.Repositories.Impl;
using vabalas_api.Utils;

namespace vabalas_api.Service.Impl
{
    public class JobService:IJobService
    {
        private readonly IJobRepository _jobRepository;
        private readonly IUserRepository _userRepository;
        

        public JobService(IJobRepository repository, IUserRepository userRepository)
        {
            _jobRepository = repository;
            _userRepository = userRepository;
        }

        public async Task<Job> AddJob(JobAddDto jobDto)
        {

            var user = await _userRepository.GetById(jobDto.UserId);
            var job = new Models.Job();

            job.Title = jobDto.Title;
            job.Description = jobDto.Description;
            job.Category = JobCategoryHelper.ParseToEnum(jobDto.Category);
            job.PhoneNumber = jobDto.PhoneNumber;
            job.Price = jobDto.Price;
            job.createdAr = DateTime.UtcNow;
            job.updatedAr = DateTime.UtcNow;
            job.User = user;

            return await _jobRepository.Add(job); 
        } 
    }
}
