using TraineeManagement.Api.Models;

namespace TraineeManagement.Api.DTO;

public class SubmissionFileResponse
{
     public string OriginalFilName { get; set; } = null!;
     public string GeneratedStorageName { get; set; } = null!;
     public string ContentType { get; set; } = null!;
     public long Size { get; set; }
     public string Checksum { get; set; } = null!;
     public string UploadedBy { get; set; } = null!;
     public DateTime Timestamps { get; set; }

     public SubmissionFileResponse(SubmissionFileMetaData submissionFileMetaData,string username)
     {
          OriginalFilName = submissionFileMetaData.OriginalFilName;
          GeneratedStorageName = submissionFileMetaData.GeneratedStorageName;
          ContentType = submissionFileMetaData.ContentType;
          Size = submissionFileMetaData.Size;
          Checksum = submissionFileMetaData.Checksum;
          UploadedBy = username;
          Timestamps = submissionFileMetaData.Timestamps;
     }
}