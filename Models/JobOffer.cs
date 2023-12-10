using vabalas_api.Enums;

namespace vabalas_api.Models
{
    public class JobOffer
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public Job Job { get; set; }
        public OfferStatus OfferStatus { get; set; }
        public string Note { get; set; }
        public DateTime JobDate { get; set; }
        public DateTime CreatedAt { get; set; }
        
    }
}
