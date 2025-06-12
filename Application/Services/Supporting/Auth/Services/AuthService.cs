using Application.Supporting.Auth.Interfaces;
using Domain.Supporting.Auth.Entities;
using Domain.Supporting.Auth.Exceptions;
using Horeca.DTOs.Supporting.Auth;
using Infrastrucutre.Repositories.Supporting.Interfaces;

namespace Application.Supporting.Auth.Services;

public class AuthService : IAuthService
{
    private readonly IAuthRepository _authRepository;
    private readonly IPasswordHasher _passwordHasher;

    public AuthService(IAuthRepository authRepository, IPasswordHasher passwordHasher)
    {
        _authRepository = authRepository;
        _passwordHasher = passwordHasher;
    }

    public async Task<bool> CreateUserAsync(CreateUserRequestDto createUserRequest)
    {
        if (await _authRepository.VerifyExistingUser(createUserRequest.Email))
        {
            throw new UserAlredyExistsException(createUserRequest.Email);
        }

        var hash = _passwordHasher.GetHash(createUserRequest.Password);

        var user = new User(
            createUserRequest.Email,
            createUserRequest.Name,
            hash,
            createUserRequest.Phone);
        return await _authRepository.AddAsync(user);
    }

    public async Task<bool> ChangePasswordAsync(ChangePasswordDto changePassworDto)
    {
        var user = await _authRepository.GetByIdAsync(changePassworDto.UserId);

        if (user is null)
        {
            throw new UserNotFoudException(changePassworDto.UserId);
        }
        
        user.ChangePassword(changePassworDto.OldPassword, changePassworDto.NewPassword, _passwordHasher);
        return await _authRepository.ChangePasswordAsync(user);
    }
}