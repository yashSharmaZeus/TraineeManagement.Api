using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TraineeManagement.Api.DTO;
using TraineeManagement.Api.Enums;
using TraineeManagement.Api.Helpers;

namespace TraineeManagement.Api.Models;

public class LearningTask
{
    public int Id { get; set; }

    [Required]  
    [Column(TypeName = "varchar(50)")]
    public string Title { get; set; } = null!;

    [Required]
    [Column(TypeName = "varchar(50)")]
    public string Description { get; set; } = null!;

    [Required]
    [Column(TypeName = "varchar(50)")]
    public string ExpectedTechStack { get; set; } = null!;

    [Required]
    [Column(TypeName = "varchar(50)")]
    public DateTime DueDate { get; set; } 

    [Required]
    [Column(TypeName = "varchar(50)")]
    public GlobalEnums.LearningTaskStatus Status { get; set; } 

    [Required]
    public DateTime CreatedDate { get; set; } 

    [Required]
    public DateTime UpdatedDate { get; set; } 

    public LearningTask(CreateLearningTaskRequest request)
    {
        Title = request.Title;
        Description = request.Description;
        ExpectedTechStack = request.ExpectedTechStack;
        DueDate = request.DueDate;
        Status = request.Status;
        CreatedDate = DateHelper.Now();
        UpdatedDate = DateHelper.Now();
    }

    private LearningTask(){}
}