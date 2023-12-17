using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using vabalas_api.Enums;

namespace vabalas_api.Models
{
    public class JobOffer
    {
        public int Id { get; set; }
        
        [Required]
        [ForeignKey("Client")]
        public int ClientId { get; set; }
        public virtual User Client { get; set; }
        
        public virtual Job Job { get; set; }
        
        public OfferStatus OfferStatus { get; set; }
        
        public string Description { get; set; }
        
        public DateTime JobDate { get; set; }
        
        public DateTime CreatedAt { get; set; }
        
        public DateTime UpdatedAt { get; set; }
        
    }
}
