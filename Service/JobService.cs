using vabalas_api.Controllers.Job.Dtos;
using vabalas_api.Enums;
using vabalas_api.Exceptions;
using vabalas_api.Models;

namespace vabalas_api.Service.Impl
{
    public class JobService : IJobService
    {
        private readonly DataContext _data;

        public JobService(DataContext data)
        {
            _data = data;
        }
        
        public async Task<IEnumerable<Job>> GetAll()
        {
            return await _data.Job.ToListAsync();
        }
        
        public async Task<Job> GetJobById(Guid jobId)
        {
            var job = await _data.Job.FindAsync(jobId);
            if (job == null)
            {
                throw new NotFoundException($"Job with id: {jobId} was not found.");
            }

            return job;
        }
        
        public async Task<List<Job>> GetAllByUserId(string userId)
        {
            return await _data.Job.Where(j => j.OwnerId == userId).ToListAsync();
        }

        public async Task<List<Job>> GetAllByCategory(JobCategory jobCategory)
        {
            return await _data.Job.Where(j => j.Category == jobCategory).ToListAsync();
        }

        public async Task<Job> AddJob(JobAddRequestDto jobAddDto, String userId)
        {
            var job = new Job();

            job.Title = jobAddDto.Title;
            job.Description = jobAddDto.Description;
            job.Category = JobCatogryParser.ToEnum(jobAddDto.Category);
            job.PhoneNumber = jobAddDto.PhoneNumber;
            job.Price = jobAddDto.Price;
            job.createdAt = DateTime.UtcNow;
            job.updatedAt = DateTime.UtcNow;
            job.OwnerId = userId;
            
            _data.Job.Add(job);
            await _data.SaveChangesAsync();
            return job;
        }
        
        public async Task<Job> UpdateJob(JobUpdateRequestDto jobRequestDto, String userId)
        {
            var job = _data.Job.FirstOrDefault(j => j.Id == jobRequestDto.Id);

            if (job == null)
            {
                throw new NotFoundException("Job was not found");
            }

            if (job.OwnerId != userId)
            {
                throw new NotValidException("Only job owner can delete the job");
            }
            
            job.Title = jobRequestDto.Title;
            job.Description = jobRequestDto.Description;
            job.PhoneNumber = jobRequestDto.PhoneNumber;
            job.Price = jobRequestDto.Price;
            job.Category = JobCatogryParser.ToEnum(jobRequestDto.Category);
            job.updatedAt = DateTime.UtcNow;
        
            _data.Job.Update(job);
            await _data.SaveChangesAsync();
            return job;
        }

        public async Task<bool> DeleteJob(Guid jobId, String userId)
        {
            var job = _data.Job.FirstOrDefault(j => j.Id == jobId);
            if (job == null)
            {
                throw new NotFoundException("Job was not found");
            }

            if (job.OwnerId != userId)
            {
                throw new NotValidException("Only job owner can delete the job");
            }

            _data.Job.Remove(job);
            await _data.SaveChangesAsync();
            
            return true;
        }
    }
}
