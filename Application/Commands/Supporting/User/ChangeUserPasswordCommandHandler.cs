using Application.Repositories.Supporting.User.Interfaces;
using Application.Supporting.Auth.Interfaces;
using Domain.Supporting.Auth.Exceptions;
using Horeca.DTOs.Supporting.Auth;
using MediatR;

namespace Application.Commands.Supporting.User;

public class ChangeUserPasswordCommandHandler : IRequestHandler<ChangePasswordCommand, bool>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;

    public ChangeUserPasswordCommandHandler(IUserRepository userRepository, IPasswordHasher passwordHasher)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }

    public async Task<bool> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
    {
        var dto = request.command;

        var user = await _userRepository.GetByIdAsync(dto.UserId);
        if (user is null)
        {
            throw new UserNotFoudException(dto.UserId);
        }
        
        user.ChangePassword(dto.OldPassword, dto.NewPassword, _passwordHasher);
        return await _userRepository.ChangePasswordAsync(user);

    }
}