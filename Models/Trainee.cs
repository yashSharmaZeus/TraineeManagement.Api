namespace TraineeManagement.Api.Models;

public class Trainee
{
    private static int id = 1;
    public int? Id { get; set; } = id++;
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public required string TechStack { get; set; }
    public required string Status { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime UpdatedDate { get; set; } = DateTime.Now;
}