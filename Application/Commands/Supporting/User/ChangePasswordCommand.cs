using Horeca.DTOs.Supporting.Auth;
using MediatR;

namespace Application.Commands.Supporting.User;

public record ChangePasswordCommand (ChangePasswordDto command) : IRequest<bool> {} 