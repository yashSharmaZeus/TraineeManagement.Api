using System.ComponentModel.DataAnnotations;
using TraineeManagement.Api.DTO;
using TraineeManagement.Api.Helpers;

namespace TraineeManagement.Api.Models;

public class LearningTask
{
    public int Id { get; set; }

    [Required]  
    public string Title { get; set; } = null!;

    [Required]
    public string Description { get; set; } = null!;

    [Required]
    public string ExpectedTechStack { get; set; } = null!;

    [Required]
    public DateTime DueDate { get; set; } 

    [Required]
    public string Status { get; set; } = null!;

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