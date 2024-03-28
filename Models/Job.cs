using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using vabalas_api.Enums;

namespace vabalas_api.Models
{
    public class Job
    {
        public Guid Id { get; set; }
        
        [Required]
        [ForeignKey("VabalasUser")]
        public String OwnerId { get; set; }
        
        [JsonIgnore]
        public virtual VabalasUser Owner { get; set; }
        
        public string Title { get; set; }
        
        public string Description { get; set; }
        
        public JobCategory Category { get; set; }   
        
        public decimal Price { get; set; }
        
        public string PhoneNumber { get; set; }
        
        public DateTime createdAt { get; set; }
        
        public DateTime updatedAt { get; set; }
        
        [JsonIgnore]
        public virtual ICollection<Job> Jobs { get; set; }
        
        [JsonIgnore]
        public virtual ICollection<JobOffer> JobOffers { get; set; }
        
        [JsonIgnore]
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
