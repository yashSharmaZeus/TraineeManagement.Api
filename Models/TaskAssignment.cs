using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TraineeManagement.Api.DTO;
using TraineeManagement.Api.Enums;

namespace TraineeManagement.Api.Models;

public class TaskAssignment
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int TraineeId { get; set; }
    public Trainee Trainee { get; set; } = null!;

    [Required]
    public int MentorId { get; set; }
    public Mentor Mentor { get; set; } = null!;

    [Required]
    public int LearningTaskId { get; set; }
    public LearningTask LearningTask { get; set; } = null!;

    [Required]
    public DateTime AssignedDate { get; set; }

    [Required]
    public DateTime DueDate { get; set; }

    [Required]
    [Column(TypeName = "VarChar(10)")]
    public GlobalEnums.TaskAssignmentStatus Status { get; set; }

    [Column(TypeName = "VarChar(50)")]
    public string? Remarks { get; set; }

    public TaskAssignment(CreateTaskAssignmentRequest request)
    {
        TraineeId = request.TraineeId;
        MentorId = request.MentorId;
        LearningTaskId = request.LearningTaskId;
        AssignedDate = request.AssignedDate;
        DueDate = request.DueDate;
        Status = request.Status;
        Remarks = request.Remarks;
    }

    private TaskAssignment(){}
}