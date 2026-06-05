using System.ComponentModel.DataAnnotations;
namespace TraineeManagement.Api.DTO;

public class UpdateTraineeRequest()
{

    [Required(ErrorMessage = "First name is required")]
    [MaxLength(50, ErrorMessage = "First name is cannot exceed 50 character")]
    public string FirstName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Last name is required")]
    [MaxLength(50, ErrorMessage = "Last name is cannot exceed 50 character ")]
    public string LastName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Valid email is required")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Tech stack is required")]
    public string TechStack { get; set; } = string.Empty;

    [Required(ErrorMessage = "Status is required")]
    [AllowedValues(["Active", "Inactive", "Completed"], ErrorMessage = "Valid status is required")]
    public string Status { get; set; } = string.Empty;
}