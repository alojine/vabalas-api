using vabalas_api.DTOs;
using vabalas_api.Exceptions;
using vabalas_api.Models;

namespace vabalas_api.Service
{
    public class ReviewSevice : IReviewService 
    {
        private readonly IJobService _jobService;
        private readonly IUserService _userService;
        private DataContext _context;

        public ReviewSevice(DataContext context, IJobService jobService, IUserService userService)
        {
            _context = context;
            _jobService = jobService;
            _userService = userService;
        }
        
        public async Task<IEnumerable<Review>> GetAll()
        {
            return await _context.Reviews.ToListAsync();
        }
        
        public async Task<Review> GetReviewById(Guid reviewId)
        {
            var review = await _context.Reviews.FindAsync(reviewId);
            if (review == null)
            {
                throw new NotFoundException($"Review with id: {reviewId} was not found.");
            }

            return review;
        }
        
        public async Task<List<Review>> GetAllByJobId(Guid jobId)
        {
            return await _context.Reviews.Where(r => r.Job.Id == jobId).ToListAsync();
        }

        public async Task<Review> Add(ReviewRequestDto reviewDto)
        {
            var review = new Review();

            var author = await _userService.GetById(reviewDto.AuthorId);
            var job = await _jobService.GetJobById(reviewDto.JobId);
            
            if (reviewDto.AuthorId == job.OwnerId)
            {
                throw new NotValidException("Job owner can not create a review for his own job.");
            }
            
            review.AuthorId = author.Id;
            review.JobId = job.Id;
            review.Title = reviewDto.Title;
            review.Description = reviewDto.Description;
            review.Rating = reviewDto.Rating;
            review.CreatedAt = DateTime.Now;
            review.UpdatedAt = DateTime.Now;
            
            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();
            return review;
        }

        public async Task<bool> Delete(Guid reviewId)
        {
            var review = await GetReviewById(reviewId);

            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
