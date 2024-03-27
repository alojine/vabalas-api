using vabalas_api.Controllers.Review.Dtos;
using vabalas_api.Exceptions;
using vabalas_api.Models;

namespace vabalas_api.Service.Impl
{
    public class ReviewSevice : IReviewService 
    {
        private readonly IJobService _jobRepository;
        private readonly IUserService _userService;
        private DataContext _context;

        public ReviewSevice(DataContext context, IJobService jobService, IUserService userService)
        {
            _context = context;
            _jobRepository = jobService;
            _userService = userService;
        }
        
        public async Task<IEnumerable<Review>> GetAll()
        {
            return await _context.Reviews.ToListAsync();
        }
        
        public async Task<Review> GetById(int reviewId)
        {
            var review = await _context.Reviews.FindAsync(reviewId);
            if (review == null)
            {
                throw new NotFoundException($"Job with id: {reviewId} was not found.");
            }

            return review;
        }
        
        // public async Task<List<Review>> GetAllByJobId(Guid jobId)
        // {
        //     return await _context.Reviews.Where(r => r.Job.Id == jobId).ToListAsync();
        // }

        // public async Task<Review> Add(ReviewAddDto reviewDto)
        // {
        //     var review = new Review();
        //     
        //     review.Author = await _userService.GetById(reviewDto.AuthorId);
        //     review.Job = await _jobRepository.GetById(reviewDto.JobId);
        //     review.Title = reviewDto.Title;
        //     review.Description = reviewDto.Description;
        //     review.Rating = reviewDto.Rating;
        //     review.CreatedAt = DateTime.Now;
        //     review.UpdatedAt = DateTime.Now;
        //
        //     _context.Reviews.Add(review);
        //     await _context.SaveChangesAsync();
        //     return review;
        // }

        public async Task<bool> Delete(int reviewId)
        {
            var review = await GetById(reviewId);

            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
