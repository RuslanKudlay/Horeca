using Horeca.DTOs.Supporting.Auth;

namespace Application.Supporting.Auth.Interfaces;

public interface IAuthService
{
    Task<bool> CreateUserAsync(CreateUserRequest createUserRequest);
}