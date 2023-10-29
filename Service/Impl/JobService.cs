using vabalas_api.Controllers.Job.Dtos;
using vabalas_api.Enums;
using vabalas_api.Exceptions;
using vabalas_api.Models;
using vabalas_api.Repositories;
using vabalas_api.Repositories.Impl;
using vabalas_api.Utils;

namespace vabalas_api.Service.Impl
{
    public class JobService : IJobService
    {
        private readonly IJobRepository _jobRepository;
        private readonly IUserRepository _userRepository;
        

        public JobService(IJobRepository repository, IUserRepository userRepository)
        {
            _jobRepository = repository;
            _userRepository = userRepository;
        }

        public async Task<Job> Add(JobAddDto jobDto)
        {

            var user = await _userRepository.GetById(jobDto.UserId);
            var job = new Models.Job();

            job.Title = jobDto.Title;
            job.Description = jobDto.Description;
            job.Category = JobCategoryHelper.ParseToEnum(jobDto.Category);
            job.PhoneNumber = jobDto.PhoneNumber;
            job.Price = jobDto.Price;
            job.createdAt = DateTime.UtcNow;
            job.updatedAt = DateTime.UtcNow;
            job.User = user;

            return await _jobRepository.Add(job); 
        }
        
        public async Task<IEnumerable<Job>> FindAll()
        {
            return await _jobRepository.GetAll();
        }

        public async Task<bool> Delete(int jobId)
        {
            var job = await _jobRepository.GetById(jobId);
            if (job == null)
            {
                throw new NotFoundException($"Job with id: {jobId} was not found.");
            }
            
            return await _jobRepository.Delete(job);
        }

        public async Task<List<Job>> GetAllByUserId(int userId)
        {
            var user = await _userRepository.GetById(userId);
            return await _jobRepository.GetAllByUserId(user);
        }

        public async Task<Job> Update(JobUpdateDto jobUpdateDto)
        {
            var job = new Job();
            
            job.Title = jobUpdateDto.Title;
            job.Description = jobUpdateDto.Description;
            job.PhoneNumber = jobUpdateDto.PhoneNumber;
            job.Price = jobUpdateDto.Price;
            job.updatedAt = DateTime.UtcNow;

            return await _jobRepository.Update(job);
        }
    }
}
