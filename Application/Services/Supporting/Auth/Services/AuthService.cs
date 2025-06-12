using Application.Supporting.Auth.Interfaces;
using Domain.Supporting.Auth.Entities;
using Domain.Supporting.Auth.Exceptions;
using Horeca.DTOs.Supporting.Auth;
using Infrastrucutre.Repositories.Supporting.Interfaces;

namespace Application.Supporting.Auth.Services;

public class AuthService : IAuthService
{
    private readonly IAuthRepository _authRepository;
    private readonly IPasswordHash _passwordHash;

    public AuthService(IAuthRepository authRepository, IPasswordHash passwordHash)
    {
        _authRepository = authRepository;
        _passwordHash = passwordHash;
    }
    
    public async Task<bool> CreateUserAsync(CreateUserRequest createUserRequest)
    {
        if (await _authRepository.VerifyExistingUser(createUserRequest.Email))
        {
            throw new UserAlredyExistsException(createUserRequest.Email);
        }
        
        var user = new User(
            createUserRequest.Email, 
            createUserRequest.Name, 
            _passwordHash.GetHash(createUserRequest.Password), 
            createUserRequest.Phone);
        return await _authRepository.AddAsync(user);
    }
}