using TraineeManagement.Api.Models;
using TraineeManagement.Api.Enums;

namespace TraineeManagement.Api.DTO;

public class ReviewResponse
{
    public int Id { get; set; }

    public int SubmissionId { get; set; }

    public int MentorId { get; set; }

    public string Feedback { get; set; } = null!;

    public int Score { get; set; }

    public GlobalEnums.ReviewStatus ReviewStatus { get; set; }

    public DateTime ReviewedDate { get; set; }

    public ReviewResponse(Review review)
    {
        Id = review.Id;
        SubmissionId = review.SubmissionId;
        MentorId = review.MentorId;
        Feedback = review.Feedback;
        Score = review.Score;
        ReviewStatus = review.ReviewStatus;
        ReviewedDate = review.ReviewedDate;
    }
}