using System.ComponentModel.DataAnnotations;
using TraineeManagement.Api.Constants;
using TraineeManagement.Api.Enums;
namespace TraineeManagement.Api.DTO;

public class CreateSubmissionRequest
{
    /// <summary>
    /// TaskAssignment Id of already existing taskAssignment.
    /// </summary>
    /// <example>1</example>
    [Required(ErrorMessage = StringConstant.TASK_ASSIGNMENT_ID_REQUIRED)]
    public int TaskAssignmentId { get; set; }

    /// <summary>
    /// Url (link) of submission.
    /// </summary>
    /// <example>https://example.com?id=1</example>
    [Required(ErrorMessage = StringConstant.SUBMISSION_URL_REQUIRED)]
    public string SubmissionUrl { get; set; } = null!;

    /// <summary>
    /// Submission note.
    /// </summary>
    /// <example>example note</example>
    [Required(ErrorMessage = StringConstant.NOTES_REQUIRED)]
    public string Notes { get; set; } = null!;

    /// <summary>
    /// submission date
    /// </summary>
    [Required(ErrorMessage = StringConstant.SUBMISSION_DATE_REQUIRED)]
    public DateTime SubmittedDate { get; set; }

    /// <summary>
    /// status.
    /// allowed value:Submitted, Resubmitted, 0, 1
    /// </summary>
    /// <example>Submitted</example>
    [Required(ErrorMessage = StringConstant.STATUS_REQUIRED)]
    [EnumDataType(typeof(GlobalEnums.SubmissionStatus), ErrorMessage = StringConstant.VALID_STATUS_REQUIRED)]
    public GlobalEnums.SubmissionStatus Status { get; set; }
}