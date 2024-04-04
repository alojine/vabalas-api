using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vabalas_api.Models
{
    public class Review
    {
        public Guid Id { get; set; }
        
        [Required]
        [ForeignKey("VabalasUser")]
        public string AuthorId { get; set; }
        
        public virtual VabalasUser Author { get; set; }
        
        [Required]
        [ForeignKey("Job")]
        public Guid JobId { get; set; }
        
        public virtual Job Job { get; set; }
        
        public string Title { get; set; }
        
        public string Description { get; set; }
        
        public decimal Rating { get; set; }

        public DateTime CreatedAt { get; set; }
        
        public DateTime UpdatedAt { get; set; }
    }
}
