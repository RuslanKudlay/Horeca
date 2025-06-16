using Horeca.DTOs.Supporting.Auth;
using MediatR;

namespace Application.Commands.Supporting.Auth;

public record CreateUserCommand (CreateUserRequestDto command) : IRequest<bool> {}