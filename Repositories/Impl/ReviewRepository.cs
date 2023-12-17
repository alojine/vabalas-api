using vabalas_api.Exceptions;
using vabalas_api.Models;

namespace vabalas_api.Repositories.Impl
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly DataContext _context;
        
        public ReviewRepository(DataContext context) 
        { 
            _context = context;
        }
        
        public async Task<IEnumerable<Review>> GetAll()
        {
            return await _context.Reviews.ToListAsync();
        }

        public async Task<Review> GetById(int reviewID)
        {
            var review = await _context.Reviews.FindAsync(reviewID);
            if (review == null)
            {
                throw new NotFoundException($"Job with id: {reviewID} was not found.");
            }

            return review;
        }
        
        public async Task<List<Review>> GetAllByJobId(int id)
        {
            return await _context.Reviews.Where(r => r.Job.Id == id).ToListAsync();
        }
        
        public async Task<Review> Add(Review review)
        {
            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();
            return review;
        }
        public async Task<Review> Update(Review review)
        {
            _context.Reviews.Update(review);
            await _context.SaveChangesAsync();
            return review;
        }
        public async Task<bool> Delete(Review review)
        {
            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
