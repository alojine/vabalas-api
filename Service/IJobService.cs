using vabalas_api.Controllers.Job.Dtos;
using vabalas_api.Models;

namespace vabalas_api.Service
{
    public interface IJobService
    {
        Task<Job> AddJob(JobAddDto jobDto);
    }
}
