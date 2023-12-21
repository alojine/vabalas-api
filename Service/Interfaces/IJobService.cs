using vabalas_api.Controllers.Job.Dtos;
using vabalas_api.Enums;
using vabalas_api.Models;

namespace vabalas_api.Service
{
    public interface IJobService
    {
        Task<IEnumerable<Job>> GetAll();

        Task<Job> GetById(int jobId);
        Task<List<Job>> GetAllByUserId(int userId);

        Task<List<Job>> GetAllByCategory(JobCategory jobCategory);
        Task<Job> Update(JobUpdateDto jobUpdateDto);
        
        Task<Job> Add(JobAddDto jobDto);

        Task<bool> Delete(int jobId);
    }
}
