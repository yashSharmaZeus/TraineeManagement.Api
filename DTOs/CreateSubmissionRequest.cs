using System.ComponentModel.DataAnnotations;
using TraineeManagement.Api.Constants;
using TraineeManagement.Api.Enums;
namespace TraineeManagement.Api.DTO;

public class CreateSubmissionRequest
{
   [Required(ErrorMessage =StringConstant.TRAINEE_ID_REQUIRED)]
    public int TaskAssignmentId {get; set;}

    [Required(ErrorMessage =StringConstant.SUBMISSION_URL_REQUIRED)]
    public string SubmissionUrl {get; set;} = null!;

    [Required(ErrorMessage =StringConstant.NOTES_REQUIRED)]
    public string Notes {get; set;} = null!;

    [Required(ErrorMessage =StringConstant.SUBMISSION_DATE_REQUIRED)]
    public DateTime SubmittedDate {get; set;}

    [Required(ErrorMessage =StringConstant.STATUS_REQUIRED)]
    public GlobalEnums.SubmissionStatus Status {get; set;}
}