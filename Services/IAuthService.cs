using TraineeManagement.Api.DTO;

namespace TraineeManagement.Api.Services;

public interface IAuthService
{
    Task<LoginResponse?> Login(LoginRequestDto request);
}