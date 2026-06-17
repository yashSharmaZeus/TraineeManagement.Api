using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TraineeManagement.Api.DTO;
using TraineeManagement.Api.Enums;
using TraineeManagement.Api.Helpers;

namespace TraineeManagement.Api.Models;

public class Trainee
{
    public int Id { get; set; }

    [Required]
    [Column(TypeName = "varchar(50)")]
    public string FirstName { get; set; } = null!;

    [Required]
    [Column(TypeName = "varchar(50)")]
    public string LastName { get; set; } = null!;

    [Required]
    [Column(TypeName = "varchar(50)")]
    public string Email { get; set; } = null!;

    [Required]
    [Column(TypeName = "varchar(50)")]
    public string TechStack { get; set; } = null!;

    [Required]
    [Column(TypeName = "varchar(10)")]
    public GlobalEnums.TraineeStatus Status { get; set; }

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

    private Trainee() { }
}