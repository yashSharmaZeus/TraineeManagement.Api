using Microsoft.AspNetCore.Mvc;
using TraineeManagement.Api.DTO;
using TraineeManagement.Api.Services;

namespace TraineeManagement.Api.Controllers;

[ApiController]
[Route("/api/auth/[controller]")]
public class LoginController : ControllerBase
{
    private IAuthService _iAuthServices;
    public LoginController(IAuthService iAuthService)
    {
        _iAuthServices = iAuthService;
    }

    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequest)
    {
        LoginResponse? response = await _iAuthServices.Login(loginRequest);
        if(response==null) return Unauthorized("Invalid username or password");
        
        return Ok(response);
    }
}
