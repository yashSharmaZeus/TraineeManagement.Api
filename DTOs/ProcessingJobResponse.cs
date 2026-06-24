using TraineeManagement.Api.Models;
using TraineeManagement.Api.Enums;

namespace TraineeManagement.Api.DTO;

public class ProcessingJobResponse
{
    public int Id { get; set; }

    public GlobalEnums.ProcessingJobStatus Status { get; set; }

    public int Attempts { get; set; }

    public string ErrorSummary { get; set; } = null!;

    public DateTime StartedTime { get; set; }

    public DateTime CompletedTime { get; set; }

    public string CorrelationId { get; set; } = null!;

    public ProcessingJobResponse(ProcessingJob processingJob)
    {
        Id = processingJob.Id;
        Status = processingJob.Status;
        Attempts = processingJob.Attempts;
        ErrorSummary = processingJob.ErrorSummary;
        StartedTime = processingJob.StartedTime;
        CompletedTime = processingJob.CompletedTime;
        CorrelationId = processingJob.CorrelationId;
    }
}