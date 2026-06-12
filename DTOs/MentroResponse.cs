using System.ComponentModel.DataAnnotations;
using TraineeManagement.Api.Models;

using TraineeManagement.Api.Constants;
namespace TraineeManagement.Api.DTO;

public class MentorResponse
{
    public int Id { get; set; }

    [Required(ErrorMessage = StringConstant.FIRST_NAME_REQUIRED)]
    public string FirstName { get; set; } 

    [Required(ErrorMessage = StringConstant.LAST_NAME_REQUIRED)]
    public string LastName { get; set; } 

    [Required(ErrorMessage = StringConstant.EMAIL_REQUIRED)]
    public string Email { get; set; } 

    [Required(ErrorMessage = StringConstant.TECH_STACK_REQUIRED)]
    public string Expertise { get; set; }

    [Required(ErrorMessage = StringConstant.STATUS_REQUIRED)]
    public string Status { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime UpdatedDate { get; set; }

    public MentorResponse(Mentor mentor)
    {
        Id = mentor.Id ;
        FirstName = mentor.FirstName;
        LastName = mentor.LastName;
        Email = mentor.Email;
        Expertise = mentor.Expertise;
        Status = mentor.Status;
        CreatedDate = mentor.CreatedDate;
        UpdatedDate = mentor.UpdatedDate;
    }
}