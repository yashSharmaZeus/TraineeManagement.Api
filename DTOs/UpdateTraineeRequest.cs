namespace TraineeManagement.Api.DTO;

public class UpdateTraineeRequest()
{
    
    public required string? FirstName { get; set; }
    public required string? LastName { get; set; }
    public required string? Email { get; set; }
    public string? TechStack { get; set; }
    public string? Status { get; set; }
}