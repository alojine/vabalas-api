using vabalas_api.Models;

namespace vabalas_api.Service.Impl;

public class AverageJobRatingDto
{
    public AverageJobRatingDto(Job job, decimal averageRating)
    {
        Job = job;
        AverageRating = averageRating;
    }

    public Job Job { get; set; }
    public decimal AverageRating { get; set; }
}