using System.ComponentModel.DataAnnotations;

namespace TraineeManagement.Api.DTO;

public class UserResponse
{
    [Required]
    public int Id {get;set;}

    [Required]
    public string Username {get;set;} = null!;

    [Required]
    public string Role {get;set;} = null!;
}