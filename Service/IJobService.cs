using vabalas_api.Controllers.Job.Dtos;
using vabalas_api.Models;

namespace vabalas_api.Service
{
    public interface IJobService
    {
        Task<Job> Add(JobAddDto jobDto);

        Task<IEnumerable<Job>> FindAll();

        Task<Job> GetById(int jobId);

        Task<bool> Delete(int jobId);

        Task<List<Job>> GetAllByUserId(int userId);

        Task<Job> Update(JobUpdateDto jobUpdateDto);

    }
}
