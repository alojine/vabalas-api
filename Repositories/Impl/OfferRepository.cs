using vabalas_api.Exceptions;
using vabalas_api.Models;

namespace vabalas_api.Repositories.Impl
{
    public class OfferRepository : IJobOfferRepository
    {
        private readonly DataContext _context;
        public OfferRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<JobOffer> Add(JobOffer jobOffer)
        {
            _context.JobOffers.Add(jobOffer);
            await _context.SaveChangesAsync();
            return jobOffer;
        }
        public async Task<JobOffer> Update(JobOffer jobOffer)
        {
            _context.JobOffers.Update(jobOffer);
            await _context.SaveChangesAsync();
            return jobOffer;
        }
        public async Task<bool> Delete(JobOffer jobOffer)
        {
            _context.JobOffers.Remove(jobOffer);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<JobOffer>> GetAll()
        {

            return await _context.JobOffers.ToListAsync();
        }
        public async Task<JobOffer> GetById(int offerId)
        {
            var jobOffer = await _context.JobOffers.FindAsync(offerId);
            if (jobOffer == null)
            {
                throw new NotFoundException($"Offer with id: {offerId} was not found.");
            }
            return jobOffer;
        }
    }
}
