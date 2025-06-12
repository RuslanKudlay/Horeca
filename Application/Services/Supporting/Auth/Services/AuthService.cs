using Application.Supporting.Auth.Interfaces;
using Domain.Supporting.Auth.Entities;
using Horeca.DTOs.Supporting.Auth;
using Infrastrucutre.Repositories.Supporting.Interfaces;

namespace Application.Supporting.Auth.Services;

public class AuthService : IAuthService
{
    private readonly IAuthRepository _authRepository;

    public AuthService(IAuthRepository authRepository)
    {
        _authRepository = authRepository;
    }
    
    public async Task<bool> CreateUserAsync(CreateUserRequest createUserRequest)
    {
        var user = new User(createUserRequest.Email, createUserRequest.Name, createUserRequest.Password, createUserRequest.Phone);
        return await _authRepository.AddAsync(user);
    }
}