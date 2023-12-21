using vabalas_api.Controllers.Job.Dtos;
using vabalas_api.Enums;
using vabalas_api.Exceptions;
using vabalas_api.Models;

namespace vabalas_api.Service.Impl
{
    public class JobService : IJobService
    {
        private readonly DataContext _context;
        private readonly IUserService _userService;

        public JobService(DataContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }
        
        public async Task<IEnumerable<Job>> GetAll()
        {
            return await _context.Job.ToListAsync();
        }
        
        public async Task<Job> GetById(int jobId)
        {
            var job = await _context.Job.FindAsync(jobId);
            if (job == null)
            {
                throw new NotFoundException($"Job with id: {jobId} was not found.");
            }

            return job;
        }
        
        public async Task<List<Job>> GetAllByUserId(int userId)
        {
            var user = await _userService.GetById(userId);
            return await _context.Job.Where(j => j.User == user).ToListAsync();
        }

        public async Task<List<Job>> GetAllByCategory(JobCategory jobCategory)
        {
            return await _context.Job.Where(j => j.Category == jobCategory).ToListAsync();
        }

        public async Task<Job> Add(JobAddDto jobDto)
        {

            var user = await _userService.GetById(jobDto.UserId);
            var job = new Job();

            job.Title = jobDto.Title;
            job.Description = jobDto.Description;
            job.Category = JobCatogryParser.ToEnum(jobDto.Category);
            job.PhoneNumber = jobDto.PhoneNumber;
            job.Price = jobDto.Price;
            job.createdAt = DateTime.UtcNow;
            job.updatedAt = DateTime.UtcNow;
            job.User = user;
            
            _context.Job.Add(job);
            await _context.SaveChangesAsync();
            return job;
        }

        public async Task<bool> Delete(int jobId)
        {
            var job = await GetById(jobId);
            
            _context.Job.Remove(job);
            await _context.SaveChangesAsync();
            
            return true;
        }

        public async Task<Job> Update(JobUpdateDto jobUpdateDto)
        {
            var job = await GetById(jobUpdateDto.Id);
            
            job.Title = jobUpdateDto.Title;
            job.Description = jobUpdateDto.Description;
            job.PhoneNumber = jobUpdateDto.PhoneNumber;
            job.User = await _userService.GetById(jobUpdateDto.UserId);
            job.Price = jobUpdateDto.Price;
            job.Category = JobCatogryParser.ToEnum(jobUpdateDto.Category);
            job.updatedAt = DateTime.UtcNow;

            _context.Job.Update(job);
            await _context.SaveChangesAsync();
            return job;
        }
    }
}
