using Application.Repositories.Supporting.User.Interfaces;
using Application.Services.Supporting.User.Interfaces;
using Domain.Supporting.Auth.Exceptions;
using Horeca.DTOs.Supporting.Auth;

namespace Application.Services.Supporting.User.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<IReadOnlyList<Domain.Supporting.Auth.Entities.User>> GetAllAsync()
    {
        return await _userRepository.GetAllAsync();
    }
}