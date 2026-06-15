using TraineeManagement.Api.Models;
using TraineeManagement.Api.Enums;

namespace TraineeManagement.Api.DTO;

public class TaskAssignmentResponse
{
    public int Id { get; set; }

    public int TraineeId { get; set; }

    public int MentorId { get; set; }

    public int LearningTaskId { get; set; }

    public DateTime AssignedDate { get; set; }

    public DateTime DueDate { get; set; }

    public GlobalEnums.TaskAssignmentStatus Status { get; set; }

    public string? Remarks { get; set; }

    public TaskAssignmentResponse(TaskAssignment taskAssignment)
    {
        Id = taskAssignment.Id;
        TraineeId = taskAssignment.TraineeId;
        MentorId = taskAssignment.MentorId;
        LearningTaskId = taskAssignment.LearningTaskId;
        AssignedDate = taskAssignment.AssignedDate;
        DueDate = taskAssignment.DueDate;
        Status = taskAssignment.Status;
        Remarks = taskAssignment.Remarks;
    }
}