using vabalas_api.Models;

namespace vabalas_api.Service.Impl;

public class JobAverageRatingDto
{
    public JobAverageRatingDto(Job job, decimal averageRating)
    {
        Job = job;
        AverageRating = averageRating;
    }

    public Job Job { get; set; }
    public decimal AverageRating { get; set; }
}