using TraineeManagement.Api.Models;
using TraineeManagement.Api.Enums;

namespace TraineeManagement.Api.DTO;

public class SubmissionResponse
{
    public int Id { get; set; }

    public int TaskAssignmentId { get; set; }
    public TaskAssignment TaskAssignment { get; set; } = null!;

    public string SubmissionUrl { get; set; } = null!;

    public string Notes { get; set; } = null!;

    public GlobalEnums.SubmissionStatus Status { get; set; }

    public DateTime SubmittedDate { get; set; }

    public SubmissionResponse(Submission submission)
    {
        Id = submission.Id;
        TaskAssignmentId = submission.TaskAssignmentId;
        SubmissionUrl = submission.SubmissionUrl;
        Notes = submission.Notes;
        Status = submission.Status;
        SubmittedDate = submission.SubmittedDate;
    }
}