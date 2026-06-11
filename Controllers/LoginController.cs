using Microsoft.AspNetCore.Mvc;
using TraineeManagement.Api.Constants;
using TraineeManagement.Api.DTO;
using TraineeManagement.Api.Services;

namespace TraineeManagement.Api.Controllers;

[ApiController]
[Route("/api/auth/[controller]")]
public class LoginController : ControllerBase
{
    private IAuthService _iAuthServices;
    private ILogger<LoginController> _logger;
    public LoginController(IAuthService iAuthService, ILogger<LoginController> logger)
    {
        _iAuthServices = iAuthService;
        _logger = logger;
    }

    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequest)
    {
        LoginResponse? response = await _iAuthServices.Login(loginRequest);
        if (response == null)
        {
            _logger.LogInformation("User login failed for Username: {Username},  Reason: Invalid username or password",loginRequest.Username);
            return Unauthorized(StringConstant.INVALID_USERNAME_PASSWORD);
        }

        _logger.LogInformation("User login successful for Username: {Username}",response.User.Username);
        return Ok(response);
    }
}
