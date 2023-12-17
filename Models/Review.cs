using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vabalas_api.Models
{
    public class Review
    {
        public int Id { get; set; }
        
        [Required]
        [ForeignKey("Author")]
        public int AuthorId { get; set; }
        public virtual User Author { get; set; }
        public virtual Job Job { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        
        public decimal Rating { get; set; }

        public DateTime CreatedAt { get; set; }
        
        public DateTime UpdatedAt { get; set; }
    }
}
