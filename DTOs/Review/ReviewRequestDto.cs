using System.ComponentModel.DataAnnotations;

namespace vabalas_api.DTOs
{
    public class ReviewRequestDto
    {
        [Required]
        public string AuthorId { get; set; }
        
        [Required]
        public Guid JobId { get; set; }
        
        [Required]
        public string Title { get; set; }
        
        [Required]
        public string Description { get; set; }
        
        [Required]
        public decimal Rating { get; set; }
    }
}
