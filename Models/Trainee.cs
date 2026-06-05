namespace TraineeManagement.Api.Models;

public class Trainee
{
    public int? Id { get; set; }
    public required string? FirstName { get; set; }
    public required string? LastName { get; set; }
    public required string? Email { get; set; }
    public string? TechStack { get; set; }
    public string? Status { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime UpdatedDate { get; set; } = DateTime.Now;
}