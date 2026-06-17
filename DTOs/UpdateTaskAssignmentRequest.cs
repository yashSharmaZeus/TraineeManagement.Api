namespace TraineeManagement.Api.DTO;

using System.ComponentModel.DataAnnotations;
using TraineeManagement.Api.Constants;
using TraineeManagement.Api.Enums;

public class UpdateTaskAssignmentRequest
{
    [Required(ErrorMessage = StringConstant.STATUS_REQUIRED)]
    public GlobalEnums.TaskAssignmentStatus Status { get; set; }
}