namespace TraineeManagement.Api.Enums;

public class GlobalEnums
{
    public enum TraineeStatus
    {
        Active = 0,
        Inactive = 1,
        Completed = 2
    }

    public enum MentorStatus
    {
        Active = 0,
        Inactive = 1,
    }

    public enum LearningTaskStatus
    {
        Draft = 0,
        Published = 1,
        Closed = 2
    }

    public enum TaskAssignmentStatus
    {
        Assigned = 0,
        InProgress = 1,
        Submitted = 2,
        Reviewed = 3,
        Completed = 4,
    }

    public enum SubmissionStatus
    {
        Submitted = 0,
        Resubmitted = 1
    }

    public enum ReviewStatus
    {
        Accepted = 0,
        ChangesRequired = 1,
        Rejected = 2
    }
}