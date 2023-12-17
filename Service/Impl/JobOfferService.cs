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
        
        public async Task<JobOffer> Add(JobOfferDto offerDto)
        {
            var offer = new JobOffer();
            var job = await _jobService.GetById(offerDto.JobId);
            
            offer.CreatedAt = DateTime.UtcNow;
            offer.JobDate = offerDto.JobDate;
            offer.OfferStatus = OfferStatusParser.ToEnum(offerDto.Status);
            offer.Description = offerDto.Description;
            offer.Job = job;

            return await _jobOfferRepository.Add(offer);
        }

        public async Task<JobOffer> RespondToOffer(JobOfferResponseDto offerResponseDto)
        {
            var offer = await GetById(offerResponseDto.JobOfferId);
            offer.OfferStatus = OfferStatusParser.ToEnum(offerResponseDto.Status);

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