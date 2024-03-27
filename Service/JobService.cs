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
        
        public async Task<Job> GetJobById(int jobId)
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
            return await _data.Job.Where(j => j.UserId == userId).ToListAsync();
        }

        public async Task<List<Job>> GetAllByCategory(JobCategory jobCategory)
        {
            return await _data.Job.Where(j => j.Category == jobCategory).ToListAsync();
        }

        public async Task<Job> AddJob(JobAddDto jobDto, String userId)
        {
            var job = new Job();

            job.Title = jobDto.Title;
            job.Description = jobDto.Description;
            job.Category = JobCatogryParser.ToEnum(jobDto.Category);
            job.PhoneNumber = jobDto.PhoneNumber;
            job.Price = jobDto.Price;
            job.createdAt = DateTime.UtcNow;
            job.updatedAt = DateTime.UtcNow;
            job.UserId = userId;
            
            _data.Job.Add(job);
            await _data.SaveChangesAsync();
            return job;
        }
        
        public async Task<Job> UpdateJob(JobUpdateDto jobDto, String userId)
        {
            var job = _data.Job.FirstOrDefault(j => j.Id == jobDto.Id);

            if (job == null)
            {
                throw new NotFoundException("Job was not found");
            }

            if (job.UserId != userId)
            {
                throw new NotValidException("Only job owner can delete the job");
            }
            
            job.Title = jobDto.Title;
            job.Description = jobDto.Description;
            job.PhoneNumber = jobDto.PhoneNumber;
            job.Price = jobDto.Price;
            job.Category = JobCatogryParser.ToEnum(jobDto.Category);
            job.updatedAt = DateTime.UtcNow;
        
            _data.Job.Update(job);
            await _data.SaveChangesAsync();
            return job;
        }

        public async Task<bool> DeleteJob(int jobId, String userId)
        {
            var job = _data.Job.FirstOrDefault(j => j.Id == jobId);
            if (job == null)
            {
                throw new NotFoundException("Job was not found");
            }

            if (job.UserId != userId)
            {
                throw new NotValidException("Only job owner can delete the job");
            }

            _data.Job.Remove(job);
            await _data.SaveChangesAsync();
            
            return true;
        }
    }
}
