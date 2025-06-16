using Application.Supporting.Auth.Interfaces;
using Domain.Supporting.Auth.Entities;
using Domain.Supporting.Auth.Exceptions;
using Infrastrucutre.Repositories.Supporting.Interfaces;
using MediatR;

namespace Application.Commands.Supporting.Auth;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, bool>
{
    private readonly IAuthRepository _authRepository;
    private readonly IPasswordHasher _passwordHasher;

    public CreateUserCommandHandler(IAuthRepository authRepository, IPasswordHasher passwordHasher)
    {
        _authRepository = authRepository;
        _passwordHasher = passwordHasher;
    }

    public async Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var dto = request.command;
        
        if (await _authRepository.VerifyExistingUser(dto.Email))
            throw new UserAlredyExistsException(dto.Email);

        var hashedPassword = _passwordHasher.GetHash(dto.Password);
        var user = new Domain.Supporting.Auth.Entities.User(dto.Email, dto.Name, hashedPassword, dto.Phone);

        return await _authRepository.AddAsync(user);
    }
}