using System.ComponentModel.DataAnnotations;
using TraineeManagement.Api.Models;

using TraineeManagement.Api.Constants;
namespace TraineeManagement.Api.DTO;

public class LearningTaskResponse
{
    public int Id { get; set; }

    [Required(ErrorMessage = StringConstant.TITLE_REQUIRED)]
    public string Title { get; set; } 

    [Required(ErrorMessage = StringConstant.DESCRIPTION_REQUIRED)]
    public string Description { get; set; } 

    [Required(ErrorMessage = StringConstant.EXPECTED_TECH_STACK_REQUIRED)]
    public string ExpectedTechStack { get; set; } 

    [Required(ErrorMessage = StringConstant.TECH_STACK_REQUIRED)]
    public DateTime DueDate { get; set; }

    [Required(ErrorMessage = StringConstant.STATUS_REQUIRED)]
    public string Status { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime UpdatedDate { get; set; }

    public LearningTaskResponse(LearningTask learningTask)
    {
        Id = learningTask.Id;
        Title = learningTask.Title;
        Description = learningTask.Description;
        ExpectedTechStack = learningTask.ExpectedTechStack;
        DueDate = learningTask.DueDate;
        Status = learningTask.Status;
        CreatedDate = learningTask.CreatedDate;
        UpdatedDate = learningTask.UpdatedDate;
    }
}