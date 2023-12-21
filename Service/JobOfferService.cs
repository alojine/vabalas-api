using vabalas_api.Controllers.JobOffer.Dtos;
using vabalas_api.Enums;
using vabalas_api.Exceptions;
using vabalas_api.Models;

namespace vabalas_api.Service.Impl
{
    public class JobOfferService : IJobOfferService
    {
        private readonly DataContext _context;
        private readonly IUserService _userService;
        private readonly IJobService _jobService;

        public JobOfferService(DataContext context, IJobService jobService, IUserService userService)
        {
            _context = context;
            _userService = userService;
            _jobService = jobService;
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
                // throw new NotFoundException($"Job with id: {jobOffer} was not found.");
                throw new NotFoundException(VabalasExceptionMessages.JobNotFound, 404);
            }

            return jobOffer;
        }
        
        public async Task<List<JobOffer>> GetAllByUserId(int userId)
        {
            var user = await _userService.GetById(userId);
            var jobOfferList = await _context.JobOffers.Where(jo => (jo.Job.User == user)).ToListAsync();
            if (jobOfferList == null)
            {
                throw new NotFoundException(VabalasExceptionMessages.JobNotFound, 404);
            }
            
            return jobOfferList;
        }
        
        public async Task<IEnumerable<JobOffer>> GetAllByUserIdAndStatus(int userId,string status)
        {
            var user = await _userService.GetById(userId);
            return await _context.JobOffers
                .Where(jo => (jo.Job.User == user) && (jo.OfferStatus == OfferStatusParser.ToEnum(status)))
                .ToListAsync();
        }
        
        public async Task<JobOffer> SendOffer(JobOfferDto offerDto)
        {
            var offer = new JobOffer();
            var client = await _userService.GetByEmail(offerDto.CustomerEmail);
            var job = await _jobService.GetById(offerDto.JobId);
            
            if (client.Id == job.UserId)
            {
                throw new NotValidException($"Cannot create offer where user with id:{client.Id} is client and job owner.");
            } 
            if (offerDto.JobDate < DateTime.Now.AddHours(1))
            {
                throw new NotSupportedException(
                    $"Offer with client id:{client.Id} cannot be offered less than 1 hour from current time.");
            }

            offer.Client = client;
            offer.Job = await _jobService.GetById(offerDto.JobId);
            offer.OfferStatus = OfferStatus.Pending;
            offer.Description = offerDto.Description;
            offer.JobDate = offerDto.JobDate;
            offer.CreatedAt = DateTime.Now;
            offer.UpdatedAt = DateTime.Now;
            
            _context.JobOffers.Add(offer);
            await _context.SaveChangesAsync();
            
            return offer;
        }

        public async Task<JobOffer> RespondToOffer(int offerId, string status)
        {
            var offer = await GetById(offerId);
            offer.OfferStatus = OfferStatusParser.ToEnum(status);

            _context.JobOffers.Update(offer);
            await _context.SaveChangesAsync();
            return offer;
        }
        
        public async Task<JobOffer> Update(JobOfferDto offerDto)
        {
            var offer = await GetById(offerDto.JobId);
            
            // possible to change description and date only
            offer.Description = offerDto.Description;
            offer.JobDate = offerDto.JobDate;
            offer.UpdatedAt = DateTime.Now;
            
            _context.JobOffers.Update(offer);
            await _context.SaveChangesAsync();
            return offer;
        }
        
        public async Task<bool> Delete (int offerId)
        {
            var offer = await GetById(offerId);

            _context.JobOffers.Remove(offer);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}