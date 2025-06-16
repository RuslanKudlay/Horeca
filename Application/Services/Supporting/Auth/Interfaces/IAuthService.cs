using Horeca.DTOs.Supporting.Auth;

namespace Application.Supporting.Auth.Interfaces;

public interface IAuthService
{
    Task<string> GetTokenAsync(LoginDto loginDto);
    Task<bool> CreateUserAsync(CreateUserRequestDto createUserRequest);
}