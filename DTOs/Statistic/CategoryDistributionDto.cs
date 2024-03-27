using vabalas_api.Enums;

namespace vabalas_api.Controllers.Statistics;

public class CategoryDistributionDto
{
    public JobCategory JobCategory { get; set; }
    public decimal Percentage { get; set; }
}