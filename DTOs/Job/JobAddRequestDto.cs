
using System.ComponentModel.DataAnnotations;

namespace vabalas_api.Controllers.Job.Dtos
{
    public class JobAddRequestDto
    {
        [Required] public string Title { get; set; } = string.Empty;
        [Required] public string Description { get; set; } = string.Empty;
        [Required] public string Category { get; set; } = string.Empty;
        [Required] public decimal Price {  get; set; }
        [Required] public string PhoneNumber { get; set; } = string.Empty;

    }
}