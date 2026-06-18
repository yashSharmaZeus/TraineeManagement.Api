namespace TraineeManagement.Api.DTO;

using System.ComponentModel.DataAnnotations;
using TraineeManagement.Api.Constants;
using TraineeManagement.Api.Enums;

public class UpdateTaskAssignmentRequest
{
    
    /// <summary>
    /// Task assignment status.
    /// allowed value: Assigned, InProgress, Submitted, Reviewed, Completed, 0, 1, 2 ,3
    /// <example>Assigned</example>
    /// </summary>
    [Required(ErrorMessage = StringConstant.STATUS_REQUIRED)]
    [EnumDataType(typeof(GlobalEnums.TaskAssignmentStatus), ErrorMessage = StringConstant.VALID_STATUS_REQUIRED)]
    public GlobalEnums.TaskAssignmentStatus Status { get; set; }
}