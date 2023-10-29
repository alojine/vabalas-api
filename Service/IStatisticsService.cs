using vabalas_api.Controllers.Statistics;

namespace vabalas_api.Service;

public interface IStatisticsService
{
    Task<int> GetTotalAmountOfJobs();

    Task<int> GetTotalAmountOfJobsByCategory(string category);

    Task<List<CategoryDistributionDto>> GetCategoryDistribution();
}