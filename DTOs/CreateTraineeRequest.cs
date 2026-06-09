using System.ComponentModel.DataAnnotations;
using TraineeManagement.Api.Constants;

namespace TraineeManagement.Api.DTO;

public class CreateTraineeRequest()
{
    
    [Required(ErrorMessage =StringConstant.FIRST_NAME_REQUIRED)]
    [MaxLength(50, ErrorMessage = StringConstant.FIRST_NAME_MAX_CHARACTER)]
    public required string FirstName { get; set; } 

    [Required(ErrorMessage = StringConstant.LAST_NAME_REQUIRED)]
    [MaxLength(50, ErrorMessage = StringConstant.LAST_NAME_MAX_CHARACTER)]
    public required string LastName { get; set; } 

    [Required(ErrorMessage = StringConstant.EMAIL_REQUIRED)]
    [EmailAddress(ErrorMessage = StringConstant.VALID_EMAIL_REQUIRED)]
    public required string Email { get; set; } 

    [Required(ErrorMessage =  StringConstant.TECH_STACK_REQUIRED)]
    public required string TechStack { get; set; } 

    [Required(ErrorMessage =  StringConstant.STATUS_REQUIRED)]
    [AllowedValues([StringConstant.STATUS_ACTIVE,StringConstant.STATUS_INACTIVE ,StringConstant.STATUS_COMPLETED ], ErrorMessage = StringConstant.VALID_STATUS_REQUIRED)]
    public required string Status { get; set; } 
}