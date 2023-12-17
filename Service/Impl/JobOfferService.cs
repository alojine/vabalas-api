using vabalas_api.Controllers.JobOffer.Dtos;
using vabalas_api.Enums;
using vabalas_api.Exceptions;
using vabalas_api.Models;
using vabalas_api.Repositories;

namespace vabalas_api.Service.Impl
{
    public class JobOfferService : IJobOfferService
    {
        private readonly IJobOfferRepository _jobOfferRepository;
        private readonly IUserService _userService;
        private readonly IJobService _jobService;

        public JobOfferService(IJobOfferRepository jobOfferRepository, IJobService jobService, IUserService userService)
        {
            _jobOfferRepository = jobOfferRepository;
            _userService = userService;
            _jobService = jobService;
        }
        
        public async Task<JobOffer> GetById(int offerId)
        {
            return await _jobOfferRepository.GetById(offerId);
        }
        
        public async Task<List<JobOffer>> GetAllByUserId(int userId)
        {
            var user = await _userService.GetById(userId);
            return await _jobOfferRepository.GetAllByUserId(user);
        }
        
        public async Task<IEnumerable<JobOffer>> GetAllByUserIdAndStatus(int userId,string status)
        {
            var user = await _userService.GetById(userId);
            return await _jobOfferRepository.GetAllByUserIdAndStatus(user, status);
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

            return await _jobOfferRepository.Add(offer);
        }

        public async Task<JobOffer> RespondToOffer(int offerId, string status)
        {
            var offer = await GetById(offerId);
            offer.OfferStatus = OfferStatusParser.ToEnum(status);

            return await _jobOfferRepository.Update(offer);
        }
        
        public async Task<IEnumerable<JobOffer>> GetAll()
        {
            return await _jobOfferRepository.GetAll();
        }
        
        public async Task<JobOffer> Update(JobOfferDto offerDto)
        {
            var offer = await _jobOfferRepository.GetById(offerDto.Id);
            
            // possible to change description and date only
            offer.Description = offerDto.Description;
            offer.JobDate = offerDto.JobDate;
            offer.UpdatedAt = DateTime.Now;
            
            return await _jobOfferRepository.Update(offer);
        }
        
        public async Task<bool> Delete (int offerId)
        {
            var jobOffer = await _jobOfferRepository.GetById(offerId);
            if(jobOffer == null)
            {
                throw new NotFoundException($"Offer with id: {offerId} was not found.");
            }
            return await _jobOfferRepository.Delete(jobOffer);
        }
    }
}