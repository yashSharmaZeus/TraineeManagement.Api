using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TraineeManagement.Api.DTO;
using TraineeManagement.Api.Enums;
using TraineeManagement.Api.Helpers;

namespace TraineeManagement.Api.Models;

public class Submission
{
    public int Id { get; set; }

    [Required]
    public int TaskAssignmentId { get; set; }
    public TaskAssignment TaskAssignment { get; set; } = null!;

    [Required]
    [Column(TypeName = "varchar(50)")]
    public string SubmissionUrl { get; set; } = null!;


    [Required]
    [Column(TypeName = "varchar(50)")]
    public string Notes { get; set; } = null!;

    [Required]
    [Column(TypeName = "varchar(10)")]
    public GlobalEnums.SubmissionStatus Status { get; set; }

    [Required]
    public DateTime SubmittedDate { get; set; }

    public Submission(CreateSubmissionRequest request)
    {
        TaskAssignmentId = request.TaskAssignmentId;
        SubmissionUrl = request.SubmissionUrl;
        Notes = request.Notes;
        Status = request.Status;
        SubmittedDate = request.SubmittedDate;
    }

    private Submission() { }
}