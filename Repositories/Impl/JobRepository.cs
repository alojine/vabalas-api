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
            return await _context.Job.FindAsync(jobId);
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
        public async Task<bool> Delete(int jobId)
        {
            var job = await _context.Job.FindAsync(jobId);
            if (job != null)
            {
                return false;
            }
            _context.Job.Remove(job);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
