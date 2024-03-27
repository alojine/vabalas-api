using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using vabalas_api.Controllers.Review.Dtos;
using vabalas_api.Service;

namespace vabalas_api.Controllers.Review
{
    [Route("api/[controller]")]

    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _reviewService.GetAll());
        }
        [HttpPost]
        // public async Task<ActionResult<Models.Review>> add(ReviewAddDto reviewDto)
        // {
        //     return Ok(await _reviewService.Add(reviewDto));
        // }
        [HttpDelete("{reviewId}")]
        public async Task<ActionResult<Models.Review>> delete(int reviewId)
        {
            return Ok(await _reviewService.Delete(reviewId));
        }
        // [HttpGet("{jobId}")]
        // public async Task<ActionResult<List<Models.Review>>> getReviewById(Guid jobId)
        // {
        //     return Ok(await _reviewService.GetAllByJobId(jobId));
        // }
    }
}
