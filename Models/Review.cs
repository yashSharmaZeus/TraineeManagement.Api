using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TraineeManagement.Api.DTO;
using TraineeManagement.Api.Enums;
using TraineeManagement.Api.Helpers;

namespace TraineeManagement.Api.Models;

public class Review
{
    public int Id { get; set; }

    [Required]
    public int SubmissionId { get; set; }
    public Submission Submission { get; set; } = null!;
   
    [Required]
    public int MentorId { get; set; }
    public Mentor Mentor { get; set; } = null!;

    [Required]
    [Column(TypeName = "varchar(200)")]
    public string Feedback { get; set; } = null!;

    [Required]
    public int Score {get; set;}

    [Required]
    [Column(TypeName = "varchar(20)")]
    public GlobalEnums.ReviewStatus ReviewStatus { get; set; }

    [Required]
    public DateTime ReviewedDate { get; set; }

    public Review(CreateReviewRequest request)
    {
        SubmissionId = request.SubmissionId;
        MentorId = request.MentorId;
        Feedback = request.Feedback;
        Score = request.Score;
        ReviewStatus = request.ReviewStatus;
        ReviewedDate = request.ReviewedDate;
    }

    private Review() { }
}