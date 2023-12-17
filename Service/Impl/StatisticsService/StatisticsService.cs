using vabalas_api.Controllers.Statistics;
using vabalas_api.Enums;
using vabalas_api.Models;
using vabalas_api.Repositories;
using vabalas_api.Utils;

namespace vabalas_api.Service.Impl;

public class StatisticsService : IStatisticsService
{
    private readonly IJobService _jobService;

    private readonly IJobRepository _jobRepository;

    private readonly IUserService _userService;

    private readonly IReviewService _reviewService;

    public StatisticsService(IJobService jobService, IJobRepository jobRepository, IUserService userService, IReviewService reviewService)
    {
        _jobService = jobService;
        _jobRepository = jobRepository;
        _userService = userService;
        _reviewService = reviewService;
    }
    
    private class RatingComparer : IComparer<decimal>
    {
        public int Compare(decimal x, decimal y)
        {
            if (x < y)
                return 1;
            if (x > y)
                return -1;
            return 0;
        }
    }
    
    public async Task<List<Job>> GetBestRatedJobs()
    {
        var jobs = await _jobService.GetAll();
        

        var jobRatings = new List<JobAverageRatingDto>();
        foreach (var job in jobs)
        {
            var reviews = await _reviewService.GetAllByJobId(job.Id);
            var averageRating = reviews.Any() ? reviews.Average(r => r.Rating) : 0;


            JobAverageRatingDto jobAverageRatingDto = new JobAverageRatingDto(job, averageRating);
            
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