using vabalas_api.Controllers.Job.Dtos;
using vabalas_api.Enums;
using vabalas_api.Models;

namespace vabalas_api.Service
{
    public interface IJobService
    {
        Task<IEnumerable<Job>> GetAll();

        Task<Job> GetJobById(int jobId);
        Task<List<Job>> GetAllByUserId(string userId);

        Task<List<Job>> GetAllByCategory(JobCategory jobCategory);
        Task<Job> UpdateJob(JobUpdateDto jobDto, String userId);

        Task<Job> AddJob(JobAddDto jobDto, String userId);

        Task<bool> DeleteJob(int jobId, String userId);
    }
}
