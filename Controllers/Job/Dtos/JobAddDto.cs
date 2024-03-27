
namespace vabalas_api.Controllers.Job.Dtos
{
    public class JobAddDto
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public decimal Price {  get; set; }
        public string PhoneNumber { get; set; } = string.Empty;

    }
}