using System.ComponentModel.DataAnnotations;
using TraineeManagement.Api.Constants;
using TraineeManagement.Api.Enums;
namespace TraineeManagement.Api.DTO;

public class UpdateTraineeRequest()
{
    
    /// <summary>
    /// First name or trainee.
    /// </summary>
    /// <example>First name</example>
    [Required(ErrorMessage = StringConstant.FIRST_NAME_REQUIRED)]
    [MaxLength(50, ErrorMessage = StringConstant.FIRST_NAME_MAX_CHARACTER)]
    public required string FirstName { get; set; }
    
    /// <summary>
    /// Last name or trainee.
    /// </summary>
    /// <example>Last name</example>
    [Required(ErrorMessage = StringConstant.LAST_NAME_REQUIRED)]
    [MaxLength(50, ErrorMessage = StringConstant.LAST_NAME_MAX_CHARACTER)]
    public required string LastName { get; set; }
    
    /// <summary>
    /// Valid Email 
    /// </summary>
    /// <example>example@gmail.com</example>
    [Required(ErrorMessage = StringConstant.EMAIL_REQUIRED)]
    [EmailAddress(ErrorMessage = StringConstant.VALID_EMAIL_REQUIRED)]
    public required string Email { get; set; }
    
    /// <summary>
    /// Trainees Tech stack
    /// </summary>
    /// <example>HTML</example>
    [Required(ErrorMessage = StringConstant.TECH_STACK_REQUIRED)]
    public required string TechStack { get; set; }
    
    /// <summary>
    /// Trainees status.
    /// Allowed values: Active, Inactive, Completed, 0, 1, 2
    /// </summary>
    /// <example>Active</example>
    [Required(ErrorMessage = StringConstant.STATUS_REQUIRED)]
    [EnumDataType(typeof(GlobalEnums.TraineeStatus), ErrorMessage = StringConstant.VALID_STATUS_REQUIRED)]
    public required GlobalEnums.TraineeStatus Status { get; set; }
}