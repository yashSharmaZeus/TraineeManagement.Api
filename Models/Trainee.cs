using System.ComponentModel.DataAnnotations;
using TraineeManagement.Api.DTO;
using TraineeManagement.Api.Helpers;

namespace TraineeManagement.Api.Models;

public class Trainee
{
    public int Id { get; set; }

    [Required]  
    public string FirstName { get; set; } = null!;

    [Required]
    public string LastName { get; set; } = null!;

    [Required]
    public string Email { get; set; } = null!;

    [Required]
    public string TechStack { get; set; } = null!;

    [Required]
    public string Status { get; set; } = null!;

    [Required]
    public DateTime CreatedDate { get; set; }

    [Required]
    public DateTime UpdatedDate { get; set; }

    public Trainee(CreateTraineeRequest request)
    {
        FirstName = request.FirstName;
        LastName = request.LastName;
        Email = request.Email;
        TechStack = request.TechStack;
        Status = request.Status;
        CreatedDate = DateHelper.Now();
        UpdatedDate = DateHelper.Now();
    }

    private Trainee(){}
}