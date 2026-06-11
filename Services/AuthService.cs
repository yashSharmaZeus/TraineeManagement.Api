using TraineeManagement.Api.DTO;
using Microsoft.AspNetCore.Identity;
using TraineeManagement.Api.Data;
using TraineeManagement.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace TraineeManagement.Api.Services;

public class AuthService : IAuthService
{
    private readonly AppDbContext _context;
    private readonly JwtService _jwtService;
    public AuthService(AppDbContext context, JwtService jwtService)
    {
        _context = context;
        _jwtService = jwtService;
    }

    public async Task<LoginResponse?> Login(LoginRequestDto request)
    {
        string Username = request.Username;
        string Password = request.Password;

        User? dbUser = await _context.User.FirstOrDefaultAsync(u => u.Username == Username);
        if (dbUser == null)
        {
            return null;
        }

        if (!ComparePasswordHash(dbUser.Username, Password, dbUser.PasswordHash))
        {
            return null;
        }

        string JwtToken = _jwtService.GenerateToken(dbUser.Id, dbUser.Username,dbUser.Role);
        int expires = Convert.ToInt32(60*60);
        UserResponse user = new UserResponse
        {
            Id = dbUser.Id,
            Username = dbUser.Username,
            Role = dbUser.Role,
        };

        LoginResponse response = new LoginResponse
        {
            JWTTokenValue = JwtToken,
            ExpiresIn = expires,
            User = user
        };

        return response;
    }

    public string ComputePasswordHash(string UserName, string plainPassword)
    {
        var passwordHasher = new PasswordHasher<string>();

        return passwordHasher.HashPassword(UserName, plainPassword);
    }

    public bool ComparePasswordHash(String User, String Password, string storedHash)
    {
        var passwordHasher = new PasswordHasher<string>();
        PasswordVerificationResult result = passwordHasher.VerifyHashedPassword(User, storedHash, Password);
        
        switch (result)
        {
            case PasswordVerificationResult.Success:
                return true;
            case PasswordVerificationResult.SuccessRehashNeeded:
                return true;
            case PasswordVerificationResult.Failed:
            default:
                return false;
        }
    }

}