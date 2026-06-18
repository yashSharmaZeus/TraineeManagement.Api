using System.ComponentModel.DataAnnotations;
using TraineeManagement.Api.Constants;
using TraineeManagement.Api.Enums;

namespace TraineeManagement.Api.DTO;

public class CreateTraineeRequest
{
    /// <summary>
    /// First name of trainee.
    /// </summary>
    /// <example>First name</example>
    [Required(ErrorMessage = StringConstant.FIRST_NAME_REQUIRED)]
    [MaxLength(50, ErrorMessage = StringConstant.FIRST_NAME_MAX_CHARACTER)]
    public string FirstName { get; set; } = null!;

    /// <summary>
    /// Last name of trainee.
    /// </summary>
    /// <example>Last name</example>
    [Required(ErrorMessage = StringConstant.LAST_NAME_REQUIRED)]
    [MaxLength(50, ErrorMessage = StringConstant.LAST_NAME_MAX_CHARACTER)]
    public string LastName { get; set; } = null!;

    /// <summary>
    /// Valid Email 
    /// </summary>
    /// <example>example@gmail.com</example>
    [Required(ErrorMessage = StringConstant.EMAIL_REQUIRED)]
    [EmailAddress(ErrorMessage = StringConstant.VALID_EMAIL_REQUIRED)]
    public string Email { get; set; } = null!;

    /// <summary>
    /// Trainees Tech stack
    /// </summary>
    /// <example>HTML</example>
    [Required(ErrorMessage = StringConstant.TECH_STACK_REQUIRED)]
    public string TechStack { get; set; } = null!;

    /// <summary>
    /// Trainees status.
    /// Allowed values: Active, Inactive, Completed, 0, 1, 2
    /// </summary>
    /// <example>Active</example>
    [Required(ErrorMessage = StringConstant.STATUS_REQUIRED)]
    [EnumDataType(typeof(GlobalEnums.TraineeStatus), ErrorMessage = StringConstant.VALID_STATUS_REQUIRED)]
    public GlobalEnums.TraineeStatus Status { get; set; }
}