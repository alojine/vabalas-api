using Microsoft.AspNetCore.Mvc;
using vabalas_api.DTOs;
using vabalas_api.Service;
using vabalas_api.Utils;

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
            var reviews = await _reviewService.GetAll();
            return Ok(MapReviewListToResponseDtoList(reviews.ToList()));
        }
    
        [HttpGet("{reviewId}")]
        public async Task<IActionResult> GetReviewById(Guid reviewId)
        {
            var review = await _reviewService.GetReviewById(reviewId); 
            return Ok(MapReviewToResponseDto(review));
        }
        
        [HttpGet("job/{jobId}")]
        public async Task<ActionResult> GetReviewsByJobId(Guid jobId)
        {
            var reviews = await _reviewService.GetAllByJobId(jobId);
            return Ok(MapReviewListToResponseDtoList(reviews.ToList()));
        }        
        
        [HttpPost]
        public async Task<ActionResult> CreateReview(ReviewRequestDto reviewDto)
        {
            await _reviewService.Add(reviewDto);
            return Ok();
        }
        
        [HttpDelete("{reviewId}")]
        public async Task<ActionResult> DeleteReview(Guid reviewId)
        {
            await _reviewService.Delete(reviewId);
            return Ok();
        }

        private static ReviewResponseDto MapReviewToResponseDto(Models.Review review)
        {
            return new ReviewResponseDto
            {
                Id = review.Id,
                AuthorId = review.AuthorId,
                JobId = review.JobId,
                Title = review.Title,
                Description = review.Description,
                Rating = DecimalHelper.RoundToTwoDecimals(review.Rating),
                CreatedAt = review.CreatedAt
            };
        }

        private static List<ReviewResponseDto> MapReviewListToResponseDtoList(List<Models.Review> reviews)
        {
            return reviews.Select(MapReviewToResponseDto).ToList();
        }
    }
}
