using System.ComponentModel.DataAnnotations;
using TraineeManagement.Api.Constants;
using TraineeManagement.Api.Enums;
namespace TraineeManagement.Api.DTO;

public class CreateReviewRequest
{
    [Required(ErrorMessage = StringConstant.SUBMISSION_ID_REQUIRED)]
    public int SubmissionId { get; set; }

    [Required(ErrorMessage = StringConstant.MENTOR_ID_REQUIRED)]
    public int MentorId { get; set; }

    [Required(ErrorMessage = StringConstant.FEED_BACK_REQUIRED)]
    public string Feedback { get; set; } = null!;

    [Required(ErrorMessage = StringConstant.SCORE_REQUIRED)]
    public int Score { get; set; }

    [Required(ErrorMessage = StringConstant.SCORE_REQUIRED)]
    public GlobalEnums.ReviewStatus ReviewStatus { get; set; }

    [Required(ErrorMessage = StringConstant.REVIEWED_DATE)]
    public DateTime ReviewedDate { get; set; }
}