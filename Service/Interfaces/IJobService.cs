using vabalas_api.Controllers.Job.Dtos;
using vabalas_api.Enums;
using vabalas_api.Models;

namespace vabalas_api.Service
{
    public interface IJobService
    {
        Task<IEnumerable<Job>> GetAll();

        Task<Job> GetJobById(Guid jobId);
        Task<List<Job>> GetAllByUserId(string userId);

        Task<List<Job>> GetAllByCategory(JobCategory jobCategory);
        Task<Job> UpdateJob(JobUpdateRequestDto jobRequestDto, String userId);

        Task<Job> AddJob(JobAddRequestDto jobAddDto, String userId);

        Task<bool> DeleteJob(Guid jobId, String userId);
    }
}
