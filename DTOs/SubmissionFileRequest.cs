using System.ComponentModel.DataAnnotations;
using TraineeManagement.Api.Constants;

namespace TraineeManagement.Api.DTO;

public class SubmissionFileRequest
{
    [Required(ErrorMessage = StringConstant.FILE_REQUIRED)]
    public IFormFile formFile {get;set;} = null!;
}