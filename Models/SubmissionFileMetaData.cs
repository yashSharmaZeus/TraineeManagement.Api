using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;
using TraineeManagement.Api.Helpers;

namespace TraineeManagement.Api.Models;

public class SubmissionFileMetaData
{

    public int Id { get; set; }

    [Required]
    public int SubmissionId { get; set; }
    public Submission Submission { get; set; } = null!;

    [Required]
    public string OriginalFilName { get; set; } = null!;

    [Required]
    [Column(TypeName = "Varchar(50)")]
    public string GeneratedStorageName { get; set; } = null!;

    [Required]
    [Column(TypeName = "Varchar(20)")]
    public string ContentType { get; set; } = null!;

    [Required]
    public long Size { get; set; }

    [Required]
    public string Checksum { get; set; } = null!;

    [Required]
    public int UploadedBy { get; set; }

    [Required]
    public DateTime Timestamps { get; set; }

    public SubmissionFileMetaData(int submissionId, string originalFilName, string generatedStorageName, string contentType, long size, string checksum, int uploadedBy)
    {
        SubmissionId = submissionId;
        OriginalFilName = originalFilName;
        GeneratedStorageName = generatedStorageName;
        ContentType = contentType;
        Size = size;
        Checksum = checksum;
        UploadedBy = uploadedBy;
        Timestamps = DateHelper.Now();
    }

    private SubmissionFileMetaData() { }
}