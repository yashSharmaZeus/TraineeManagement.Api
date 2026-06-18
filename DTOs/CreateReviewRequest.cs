using System.ComponentModel.DataAnnotations;
using TraineeManagement.Api.Constants;
using TraineeManagement.Api.Enums;
namespace TraineeManagement.Api.DTO;

public class CreateReviewRequest
{
    /// <summary>
    /// Submission Id of already existing submission.
    /// </summary>
    /// <example>1</example>    
    [Required(ErrorMessage = StringConstant.SUBMISSION_ID_REQUIRED)]
    public int SubmissionId { get; set; }

    /// <summary>
    /// Mentor Id of already existing mentor.
    /// </summary>
    /// <example>1</example>
    [Required(ErrorMessage = StringConstant.MENTOR_ID_REQUIRED)]
    public int MentorId { get; set; }

    /// <summary>
    /// Feedback
    /// </summary>
    /// <example>need improvement</example>
    [Required(ErrorMessage = StringConstant.FEED_BACK_REQUIRED)]
    public string Feedback { get; set; } = null!;

    /// <summary>
    /// score of submission
    /// </summary>
    /// <example>50</example>
    [Required(ErrorMessage = StringConstant.SCORE_REQUIRED)]
    public int Score { get; set; }

    /// <summary>
    /// Status of review
    /// allowed value: Accepted, ChangesRequired, Rejected ,0 ,1 ,2
    /// </summary>
    /// <example>Accepted</example>
    [Required(ErrorMessage = StringConstant.SCORE_REQUIRED)]
    [EnumDataType(typeof(GlobalEnums.ReviewStatus), ErrorMessage = StringConstant.VALID_STATUS_REQUIRED)]
    public GlobalEnums.ReviewStatus ReviewStatus { get; set; }

    /// <summary>
    /// Date of review
    /// </summary>
    [Required(ErrorMessage = StringConstant.REVIEWED_DATE)]
    public DateTime ReviewedDate { get; set; }
}