using System.ComponentModel.DataAnnotations;
using TraineeManagement.Api.Constants;
using TraineeManagement.Api.Enums;
namespace TraineeManagement.Api.DTO;

public class CreateTaskAssignmentRequest
{
   [Required(ErrorMessage =StringConstant.TRAINEE_ID_REQUIRED)]
    public int TraineeId {get; set;}

    [Required(ErrorMessage =StringConstant.MENTOR_ID_REQUIRED)]
    public int MentorId {get; set;}

    [Required(ErrorMessage =StringConstant.LEARNING_TASK_ID_REQUIRED)]
    public int LearningTaskId  {get;set;}

    [Required(ErrorMessage =StringConstant.ASSIGNED_DATE__REQUIRED)]
    public DateTime AssignedDate {get; set;}

    [Required(ErrorMessage =StringConstant.DUE_DATE_REQUIRED)]
    public DateTime DueDate {get; set;}

    [Required(ErrorMessage =StringConstant.STATUS_REQUIRED)]
    public GlobalEnums.TaskAssignmentStatus Status {get; set;}

    [MaxLength(50, ErrorMessage = StringConstant.REMARK_MAX_CHARACTER)]
    public string? Remarks {get; set;}
}