using vabalas_api.Controllers.Statistics;
using vabalas_api.Enums;
using vabalas_api.Models;
using vabalas_api.Utils;

namespace vabalas_api.Service.Impl;

public class StatisticsService : IStatisticsService
{
    private readonly IJobService _jobService;

    private readonly IReviewService _reviewService;

    public StatisticsService(IJobService jobService, IReviewService reviewService)
    {
        _jobService = jobService;
        _reviewService = reviewService;
    }
    
    public async Task<List<Job>> GetBestRatedJobs()
    {
        var jobs = await _jobService.GetAll();
        
        var jobRatings = new List<JobAverageRatingDto>();
        foreach (var job in jobs)
        {
            var reviews = await _reviewService.GetAllByJobId(job.Id);
            var averageRating = reviews.Any() ? reviews.Average(r => r.Rating) : 0;
            
            var jobAverageRatingDto = new JobAverageRatingDto(job, averageRating);
            
            jobRatings.Add(jobAverageRatingDto);
        }
        
        var bestRatedJobs = jobRatings.OrderByDescending(j => j.AverageRating).Select(j => j.Job).ToList();

        return bestRatedJobs;
    }

    public async Task<int> GetTotalAmountOfJobs()
    {
        var jobs = await _jobService.GetAll();
        return jobs.Count();
    }

    public async Task<int> GetTotalAmountOfJobsByCategory(string jobCategory)
    {
        var jobs = await _jobService.GetAllByCategory(JobCatogryParser.ToEnum(jobCategory));
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
            
            var currentCategoryJobs = (await _jobService.GetAllByCategory(category)).Count;
            
            categoryDistributionDto.Percentage = currentCategoryJobs != 0
                ? PercentageHelper.GetPercentage(totalJobs, currentCategoryJobs)
                : 0;
            
            categoryDistributionList.Add(categoryDistributionDto);
        }

        return categoryDistributionList;
    }
}