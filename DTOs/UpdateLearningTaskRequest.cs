using System.ComponentModel.DataAnnotations;
using TraineeManagement.Api.Constants;
using TraineeManagement.Api.Enums;

namespace TraineeManagement.Api.DTO;

public class UpdateLearningTaskRequest
{

    [Required(ErrorMessage = StringConstant.TITLE_REQUIRED)]
    [MaxLength(50, ErrorMessage = StringConstant.TITLE_MAX_CHARACTER)]
    public string Title { get; set; } = null!;

    [Required(ErrorMessage = StringConstant.DESCRIPTION_REQUIRED)]
    [MaxLength(200, ErrorMessage = StringConstant.DESCRIPTION_MAX_CHARACTER)]
    public string Description { get; set; } = null!;

    [Required(ErrorMessage = StringConstant.EXPECTED_TECH_STACK_REQUIRED)]
    public string ExpectedTechStack { get; set; } = null!;

    [Required(ErrorMessage = StringConstant.DUE_DATE_REQUIRED)]
    public DateTime DueDate { get; set; }

    [Required(ErrorMessage = StringConstant.STATUS_REQUIRED)]
    public GlobalEnums.LearningTaskStatus Status { get; set; }
}