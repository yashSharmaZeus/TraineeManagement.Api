using System.ComponentModel.DataAnnotations;
using TraineeManagement.Api.Constants;
using TraineeManagement.Api.Enums;
namespace TraineeManagement.Api.DTO;

public class CreateTaskAssignmentRequest
{
    /// <summary>
    /// trainee id of existing trainee.
    /// </summary>
    /// <example>1</example>    
    [Required(ErrorMessage = StringConstant.TRAINEE_ID_REQUIRED)]
    public int TraineeId { get; set; }

    /// <summary>
    /// mentor id of existing mentor.
    /// </summary>
    /// <example>1</example>
    [Required(ErrorMessage = StringConstant.MENTOR_ID_REQUIRED)]
    public int MentorId { get; set; }

    /// <summary>
    /// learning task id of already existing learning task.
    /// </summary>
    /// <example>1</example>
    [Required(ErrorMessage = StringConstant.LEARNING_TASK_ID_REQUIRED)]
    public int LearningTaskId { get; set; }

    /// <summary>
    /// assigned date
    /// </summary>
    [Required(ErrorMessage = StringConstant.ASSIGNED_DATE_REQUIRED)]
    public DateTime AssignedDate { get; set; }

    /// <summary>
    /// due date
    /// </summary>
    [Required(ErrorMessage = StringConstant.DUE_DATE_REQUIRED)]
    public DateTime DueDate { get; set; }

    /// <summary>
    /// Task assignment status.
    /// allowed value: Assigned, InProgress, Submitted, Reviewed, Completed, 0, 1, 2 ,3
    /// <example>Assigned</example>
    /// </summary>
    [Required(ErrorMessage = StringConstant.STATUS_REQUIRED)]
    [EnumDataType(typeof(GlobalEnums.TaskAssignmentStatus), ErrorMessage = StringConstant.VALID_STATUS_REQUIRED)]
    public GlobalEnums.TaskAssignmentStatus Status { get; set; }

    /// <summary>
    /// remarks of assigned task
    /// </summary>
    /// <example>works correctly</example>
    [MaxLength(50, ErrorMessage = StringConstant.REMARK_MAX_CHARACTER)]
    public string? Remarks { get; set; }
}