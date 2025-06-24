using Horeca.DTOs.Core.MenuManagement;
using MediatR;

namespace Application.Commands.Core.MenuManagement;

public class CreateMenuGroupCommand : IRequest<bool>
{
    public List<CreateMenuGroupDto> DtoList { get; set; }
    public CreateMenuGroupCommand(List<CreateMenuGroupDto> dtoList)
    {
        DtoList = dtoList;
    }
}