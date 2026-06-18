using System.ComponentModel.DataAnnotations;
using TraineeManagement.Api.Constants;
using TraineeManagement.Api.Enums;

namespace TraineeManagement.Api.DTO;

public class UpdateLearningTaskRequest
{

    /// <summary>
    /// Title of learning task.
    /// </summary>
    /// <example>task1</example>
    [Required(ErrorMessage = StringConstant.TITLE_REQUIRED)]
    [MaxLength(50, ErrorMessage = StringConstant.TITLE_MAX_CHARACTER)]
    public string Title { get; set; } = null!;

    /// <summary>
    /// Description of learning task
    /// </summary>
    /// <example>Description1</example>
    [Required(ErrorMessage = StringConstant.DESCRIPTION_REQUIRED)]
    [MaxLength(200, ErrorMessage = StringConstant.DESCRIPTION_MAX_CHARACTER)]
    public string Description { get; set; } = null!;

    /// <summary>
    /// Expected tech stack of learning task
    /// </summary>
    /// <example>dotnet</example>
    [Required(ErrorMessage = StringConstant.EXPECTED_TECH_STACK_REQUIRED)]
    public string ExpectedTechStack { get; set; } = null!;

    /// <summary>
    /// Due date.
    /// </summary>
    [Required(ErrorMessage = StringConstant.DUE_DATE_REQUIRED)]
    public DateTime DueDate { get; set; }

    /// <summary>
    /// status of learning task.
    /// allowed values: Draft ,Published ,Closed, 0, 1, 2
    /// </summary>
    /// <example>Draft</example>
    [Required(ErrorMessage = StringConstant.STATUS_REQUIRED)]
    [EnumDataType(typeof(GlobalEnums.LearningTaskStatus), ErrorMessage = StringConstant.VALID_STATUS_REQUIRED)]
    public GlobalEnums.LearningTaskStatus Status { get; set; }
}