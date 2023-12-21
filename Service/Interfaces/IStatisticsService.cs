using vabalas_api.Controllers.Statistics;
using vabalas_api.Models;

namespace vabalas_api.Service;

public interface IStatisticsService
{
    Task<int> GetTotalAmountOfJobs();

    Task<int> GetTotalAmountOfJobsByCategory(string jobCategory);

    Task<List<CategoryDistributionDto>> GetCategoryDistribution();

    Task<List<Job>> GetBestRatedJobs();
}