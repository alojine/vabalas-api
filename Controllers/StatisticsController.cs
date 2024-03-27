using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using vabalas_api.Mappers;
using vabalas_api.Service;

namespace vabalas_api.Controllers.Statistics;

[Route("api/[controller]")]
[ApiController]
public class StatisticsController : ControllerBase
{
    private readonly IStatisticsService _statisticsService;

    public StatisticsController(IStatisticsService statisticsService)
    {
        _statisticsService = statisticsService;
    }
    
    [HttpGet("total")]
    public async Task<ActionResult<int>> GetTotalAmountOfJobs()
    {
        return Ok(await _statisticsService.GetTotalAmountOfJobs());
    }
    
    [HttpGet("category/{category}")]
    public async Task<ActionResult<int>> GetAmountOfJobsByCategory(string category)
    {
        return Ok(await _statisticsService.GetTotalAmountOfJobsByCategory(category));
    }
    
    [HttpGet("distribution")]
    public async Task<ActionResult<int>> GetCategoryDistribution()
    {
        return Ok(await _statisticsService.GetCategoryDistribution());
    }
    
    // [HttpGet("best-jobs")]
    // public async Task<ActionResult<List<Models.Job>>> GetBestJobs()
    // {
    //     return Ok(await _statisticsService.GetBestRatedJobs());
    // }
}