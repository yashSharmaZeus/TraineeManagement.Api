using System.ComponentModel.DataAnnotations;
using TraineeManagement.Api.Constants;

namespace TraineeManagement.Api.DTO;

public class LoginRequestDto
{
    [Required(ErrorMessage = StringConstant.USERNAME_REQUIRED)]
    public string Username {get;set;} = null!;

    [Required(ErrorMessage = StringConstant.PASSWORD_REQUIRED)]
    public string Password {get;set;} = null!;
}