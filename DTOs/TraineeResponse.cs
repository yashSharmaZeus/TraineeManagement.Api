using System.ComponentModel.DataAnnotations;
using TraineeManagement.Api.Models;
namespace TraineeManagement.Api.DTO;

public class TraineeResponse
{
    public int? Id { get; set; }
    [Required(ErrorMessage = "First name is required")]
    public string FirstName { get; set; } = string.Empty;
    [Required(ErrorMessage = "Last name is required")]
    public string LastName { get; set; } = string.Empty;
    [Required(ErrorMessage = "Email is required")]
    public string Email { get; set; } = string.Empty;
    public string? TechStack { get; set; }
    public string? Status { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }

    public TraineeResponse(Trainee trainee)
    {
        Id = trainee.Id;
        FirstName = trainee.FirstName;
        LastName = trainee.LastName;
        Email = trainee.Email;
        TechStack = trainee.TechStack;
        Status = trainee.Status;
        CreatedDate = trainee.CreatedDate;
        UpdatedDate = trainee.UpdatedDate;
    }
}