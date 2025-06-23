using Horeca.DTOs.Core.MenuManagement;
using MediatR;

namespace Application.Commands.Core.MenuManagement;

public record CreateMenuCommand (CreateMenuDto dto) : IRequest<bool> {} 