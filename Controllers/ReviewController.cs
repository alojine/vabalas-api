using Microsoft.AspNetCore.Mvc;
using vabalas_api.DTOs;
using vabalas_api.Service;

namespace vabalas_api.Controllers.Review
{
    [Route("api/reviews")]

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
    
        [HttpGet("{reviewId}")]
        public async Task<IActionResult> GetReviewById(Guid reviewId)
        {
            return Ok(await _reviewService.GetReviewById(reviewId));
        }
        
        [HttpGet("{jobId}")]
        public async Task<ActionResult> GetReviewByJobId(Guid jobId)
        {
            return Ok(await _reviewService.GetAllByJobId(jobId));
        }        
        
        [HttpPost]
        public async Task<ActionResult> CreateReview(ReviewRequestDto reviewDto)
        {
            return Ok(await _reviewService.Add(reviewDto));
        }
        
        [HttpDelete("{reviewId}")]
        public async Task<ActionResult> DeleteReview(Guid reviewId)
        {
            return Ok(await _reviewService.Delete(reviewId));
        }
    }
}
