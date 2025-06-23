using Horeca.DTOs.Supporting.Auth;
using Horeca.DTOs.Supporting.User;
using MediatR;

namespace Application.Commands.Supporting.User;

public record ChangePasswordCommand (ChangePasswordDto dto) : IRequest<bool> {} 