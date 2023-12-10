using vabalas_api.Controllers.Statistics;
using vabalas_api.Enums;
using vabalas_api.Repositories;
using vabalas_api.Utils;

namespace vabalas_api.Service.Impl;

public class StatisticsService : IStatisticsService
{
    private readonly IJobService _jobService;

    private readonly IJobRepository _jobRepository;

    public StatisticsService(IJobService jobService, IJobRepository jobRepository)
    {
        _jobService = jobService;
        _jobRepository = jobRepository;
    }

    public async Task<int> GetTotalAmountOfJobs()
    {
        var jobs = await _jobService.FindAll();
        return jobs.Count();
    }

    public async Task<int> GetTotalAmountOfJobsByCategory(string category)
    {
        var jobCategory = JobCatogryParser.ToEnum(category);
        var jobs = await _jobRepository.GetAllByCategory(jobCategory);
        return jobs.Count;
    }

    public async Task<List<CategoryDistributionDto>> GetCategoryDistribution()
    {
        var categoryDistributionList = new List<CategoryDistributionDto>();
        var totalJobs = await GetTotalAmountOfJobs();
        foreach (JobCategory category in Enum.GetValues(typeof(JobCategory)))
        {
            var categoryDistributionDto = new CategoryDistributionDto();
            categoryDistributionDto.JobCategory = category;
            
            var currentCategoryJobs = (await _jobRepository.GetAllByCategory(category)).Count;
            if (currentCategoryJobs != 0)
            {
                categoryDistributionDto.Percentage = PercentageHelper.GetPercentage(totalJobs, currentCategoryJobs);
            }
            else
            {
                categoryDistributionDto.Percentage = 0;
            }
            
            categoryDistributionList.Add(categoryDistributionDto);
        }

        return categoryDistributionList;
    }
}