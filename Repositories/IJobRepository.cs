using vabalas_api.Models;

namespace vabalas_api.Repositories
{
    public interface IJobRepository
    {
        Task<IEnumerable<Job>> GetAll();

        Task<List<Job>> GetAllByUserId(User user);
        
        Task<Job> GetById(int jobId);

        Task<Job> Add(Job job);

        Task<Job> Update(Job job);
        
        Task<bool> Delete(Job job);
    }
}
