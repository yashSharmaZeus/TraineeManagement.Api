using System.ComponentModel.DataAnnotations;

namespace TraineeManagement.Api.DTO;

public class LoginResponse
{
    [Required]
    public string JWTTokenValue {get;set;} = null!;

    [Required]
    public int ExpiresIn {get;set;} 

    [Required]
    public UserResponse User {get;set;} = null!;
}