using System.ComponentModel.DataAnnotations;
using TraineeManagement.Api.Constants;

namespace TraineeManagement.Api.DTO;

public class CreateLearningTaskRequest
{
    
    [Required(ErrorMessage =StringConstant.TITLE_REQUIRED)]
    [MaxLength(50, ErrorMessage = StringConstant.TITLE_MAX_CHARACTER)]
    public string Title { get; set; } = null!;

    [Required(ErrorMessage = StringConstant.DESCRIPTION_REQUIRED)]
    [MaxLength(200, ErrorMessage = StringConstant.DESCRIPTION_MAX_CHARACTER)]
    public string Description { get; set; } = null!;

    [Required(ErrorMessage = StringConstant.EXPECTED_TECH_STACK_REQUIRED)]
    public string ExpectedTechStack { get; set; } = null!;

    [Required(ErrorMessage =  StringConstant.DUE_DATE_REQUIRED)]
    public DateTime DueDate { get; set; } 

    [Required(ErrorMessage =  StringConstant.STATUS_REQUIRED)]
    [AllowedValues([StringConstant.STATUS_DRAFT,StringConstant.STATUS_PUBLISHED,StringConstant.STATUS_CLOSED ], ErrorMessage = StringConstant.VALID_STATUS_REQUIRED)]
    public string Status { get; set; } = null!;
}