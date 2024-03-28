namespace vabalas_api.Controllers.Job.Dtos;

public class JobResponseDto
{
    public Guid JobId { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? Category { get; set; }
    public decimal Price { get; set; }
    public string? PhoneNumber { get; set; }
}