namespace TraineeManagement.Api.Enums;

public class GlobalEnums
{
    public enum TraineeStatus
    {
        Active,
        Inactive,
        Completed
    }

    public enum MentorStatus
    {
        Active,
        Inactive,
    }

    public enum LearningTaskStatus
    {
        Draft,
        Published,
        Closed
    }

    public enum TaskAssignmentStatus
    {
        Assigned,
        InProgress,
        Submitted,
        Reviewed,
        Completed,
    }

    
}