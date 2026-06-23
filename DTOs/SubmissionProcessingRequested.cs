using System.ComponentModel.DataAnnotations;
using TraineeManagement.Api.Helpers;

namespace TraineeManagement.Api.DTO;

public class SubmissionProcessingRequested
{
    [Required]
    public string MessageId { get; set; } = null!;
    
    [Required]
    public string CorrelationId { get; set; } = null!;
    
    [Required]
    public int SubmissionId { get; set; }
   
    [Required]
    public int FileId { get; set; }
   
    [Required]
    public DateTime RequestedAt { get; set; }
   
    [Required]
    public int ContractVersion { get; set; }

    public SubmissionProcessingRequested(int submissionId, int fileId,int contractVersion)
    {
        MessageId = Guid.NewGuid().ToString();
        CorrelationId = Guid.NewGuid().ToString();
        SubmissionId = submissionId;
        FileId = fileId;
        RequestedAt = DateHelper.Now();
        ContractVersion = contractVersion;
    }
}