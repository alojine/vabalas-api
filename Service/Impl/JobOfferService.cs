using vabalas_api.Controllers.JobOffer.Dtos;
using vabalas_api.Enums;
using vabalas_api.Exceptions;
using vabalas_api.Models;
using vabalas_api.Repositories;

namespace vabalas_api.Service.Impl
{
    public class JobOfferService : IJobOfferService
    {
        private readonly IJobOfferRepository _offerRepository;
        private readonly IUserRepository _userRepository;
        private readonly IJobRepository _jobRepository;

        public JobOfferService(IJobOfferRepository repository,IJobRepository jobRepository, IUserRepository userRepository)
        {
            _jobRepository = jobRepository;
            _offerRepository = repository;
            _userRepository = userRepository;
        }
        public async Task<JobOffer> Add(JobOfferDto offerDto)
        {
            var offer = new JobOffer();
            var job = await _jobRepository.GetById(offerDto.JobId);
            
            offer.CustomerName = offerDto.CustomerName;
            offer.CustomerPhoneNumber = offerDto.CustomerPhoneNumber;
            offer.CreatedAt = DateTime.UtcNow;
            offer.JobDate = offerDto.JobDate;
            offer.OfferStatus = OfferStatusParser.ToEnum(offerDto.Status);
            offer.Note = offerDto.Note;
            offer.Job = job;

            return await _offerRepository.Add(offer);
        }
        public async Task<IEnumerable<JobOffer>> FindAll()
        {
            return await _offerRepository.GetAll();
        }
        public async Task<IEnumerable<JobOffer>> GetAllByUserAndStatus(int userId,string status)
        {
            var user = await _userRepository.GetById(userId);
            return await _offerRepository.GetAllByUserIdAndStatus(user, status);
        }
        public async Task<JobOffer> GetById(int offerId)
        {
            return await _offerRepository.GetById(offerId);
        }
        public async Task<bool> Delete (int offerId)
        {
            var jobOffer = await _offerRepository.GetById(offerId);
            if(jobOffer == null)
            {
                throw new NotFoundException($"Offer with id: {offerId} was not found.");
            }
            return await _offerRepository.Delete(jobOffer);
        }
        public async Task<JobOffer> Update(JobOfferDto offerDto)
        {
            var offer = await _offerRepository.GetById(offerDto.Id);
            var job = await _jobRepository.GetById(offerDto.JobId);

            offer.CustomerName = offerDto.CustomerName;
            offer.CustomerPhoneNumber = offerDto.CustomerPhoneNumber;
            offer.JobDate = offerDto.JobDate;
            offer.OfferStatus = OfferStatusParser.ToEnum(offerDto.Status);
            offer.Note = offerDto.Note;
            offer.Job = job;

            return await _offerRepository.Update(offer);

        }
        public async Task<List<JobOffer>> GetAllByUserId(int userId)
        {
            var user = await _userRepository.GetById(userId);
            return await _offerRepository.GetAllByUserId(user);
        }

    }
}
