using Horeca.DTOs.Core.MenuManagement;
using MediatR;

namespace Application.Commands.Core.MenuManagement;

public class UpdateMenuGroupCommand : IRequest<bool>
{
    public List<UpdateMenuGroupDto> DtoList { get; set; }

    public UpdateMenuGroupCommand(List<UpdateMenuGroupDto> dtoList)
    {
        DtoList = dtoList;
    }
}