using System.ComponentModel.DataAnnotations;
using TraineeManagement.Api.Constants;
using TraineeManagement.Api.Helpers;

namespace TraineeManagement.Api.Models;

public class User
{
    [Key]
    public int Id {get; set;}

    [Required]
    public string Username {get; set;} = null!;

    [Required]
    [EmailAddress]
    public string Email {get; set;} = null!;

    [Required]
    public string PasswordHash {get; set;} = null!;

    [Required]
    [AllowedValues([StringConstant.ROLE_ADMIN,StringConstant.ROLE_MENTOR ,StringConstant.ROLE_TRAINEE ])]
    public string Role {get; set;} = null!;

    public DateTime CreatedDate {get; set;} = DateHelper.Now();

    public DateTime UpdateDate {get; set;} = DateHelper.Now();

}