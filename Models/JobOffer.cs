using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using vabalas_api.Enums;

namespace vabalas_api.Models
{
    public class JobOffer
    {
        public Guid Id { get; set; }
        
        [Required]
        [ForeignKey("VabalasUser")]
        public string SenderId { get; set; }
        
        public virtual VabalasUser Sender { get; set; }
        
        [Required]
        [ForeignKey("Job")]
        public Guid JobId { get; set; }
        
        public virtual Job Job { get; set; }
        
        public OfferStatus OfferStatus { get; set; }
        
        public string Description { get; set; }
        
        public DateTime JobDate { get; set; }
        
        public DateTime CreatedAt { get; set; }
        
        public DateTime UpdatedAt { get; set; }
        
    }
}
