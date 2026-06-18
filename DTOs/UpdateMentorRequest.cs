using System.ComponentModel.DataAnnotations;
using TraineeManagement.Api.Constants;
using TraineeManagement.Api.Enums;
namespace TraineeManagement.Api.DTO;

public class UpdateMentorRequest
{

    /// <summary>
    /// First name or mentor.
    /// </summary>
    /// <example>First name</example>    
    [Required(ErrorMessage = StringConstant.FIRST_NAME_REQUIRED)]
    [MaxLength(50, ErrorMessage = StringConstant.FIRST_NAME_MAX_CHARACTER)]
    public string FirstName { get; set; } = null!;

    /// <summary>
    /// Last name or mentor.
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
    /// mentors Expertise
    /// </summary>
    /// <example>HTML</example>
    [Required(ErrorMessage = StringConstant.EXPERTISE_REQUIRED)]
    public string Expertise { get; set; } = null!;

    /// <summary>
    /// mentors status.
    /// Allowed values: Active, Inactive, 0, 1
    /// </summary>
    /// <example>Active</example>
    [Required(ErrorMessage = StringConstant.STATUS_REQUIRED)]
    [EnumDataType(typeof(GlobalEnums.MentorStatus), ErrorMessage = StringConstant.VALID_STATUS_REQUIRED)]
    public GlobalEnums.MentorStatus Status { get; set; }
}