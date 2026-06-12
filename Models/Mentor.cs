using System.ComponentModel.DataAnnotations;
using TraineeManagement.Api.DTO;
using TraineeManagement.Api.Helpers;

namespace TraineeManagement.Api.Models;

public class Mentor
{
    public int Id { get; set; }

    [Required]  
    public string FirstName { get; set; } = null!;

    [Required]
    public string LastName { get; set; } = null!;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;

    [Required]
    public string Expertise { get; set; } = null!;

    [Required]
    public string Status { get; set; } = null!;

    [Required]
    public DateTime CreatedDate { get; set; } 

    [Required]
    public DateTime UpdatedDate { get; set; } 

    public Mentor(CreateMentorRequest request)
    {
        FirstName = request.FirstName;
        LastName = request.LastName;
        Email = request.Email;
        Expertise = request.Expertise;
        Status = request.Status;
        CreatedDate = DateHelper.Now();
        UpdatedDate = DateHelper.Now();
    }

    private Mentor(){}
}