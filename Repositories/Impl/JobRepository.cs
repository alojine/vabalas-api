using vabalas_api.Exceptions;
using vabalas_api.Models;

namespace vabalas_api.Repositories.Impl
{
    public class JobRepository : IJobRepository
    {
        private readonly DataContext _context;
        public JobRepository(DataContext context)
        {
            _context = context;
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

        public async Task<List<Job>> GetAllByUserId(User user)
        {
            return await _context.Job.Where(j => j.User == user).ToListAsync();
        }
            
        public async Task<Job> Add(Job job)
        {
            _context.Job.Add(job);
            await _context.SaveChangesAsync();
            return job;
        }
        
        public async Task<Job> Update(Job job)
        {
            _context.Job.Update(job);
            await _context.SaveChangesAsync();
            return job;
        }
        
        public async Task<bool> Delete(Job job)
        {
            _context.Job.Remove(job);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
