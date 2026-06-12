using System.ComponentModel.DataAnnotations;
using TraineeManagement.Api.Constants;
namespace TraineeManagement.Api.DTO;

public class UpdateMentorRequest
{

    [Required(ErrorMessage = StringConstant.FIRST_NAME_REQUIRED)]
    [MaxLength(50, ErrorMessage = StringConstant.FIRST_NAME_MAX_CHARACTER)]
    public string FirstName { get; set; } = null!;

    [Required(ErrorMessage = StringConstant.LAST_NAME_REQUIRED)]
    [MaxLength(50, ErrorMessage = StringConstant.LAST_NAME_MAX_CHARACTER)]
    public string LastName { get; set; } = null!;

    [Required(ErrorMessage = StringConstant.EMAIL_REQUIRED)]
    [EmailAddress(ErrorMessage = StringConstant.VALID_EMAIL_REQUIRED)]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = StringConstant.EXPERTISE_REQUIRED)]
    public string Expertise { get; set; } = null!;

    [Required(ErrorMessage = StringConstant.STATUS_REQUIRED)]
    [AllowedValues([StringConstant.STATUS_ACTIVE, StringConstant.STATUS_INACTIVE], ErrorMessage = StringConstant.VALID_STATUS_REQUIRED)]
    public string Status { get; set; } = null!;
}