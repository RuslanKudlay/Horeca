using Application.Eceptions;
using Application.Repositories.Core.MenuManagement;
using Domain.Core.Menu;
using MediatR;

namespace Application.Commands.Core.MenuManagement;

public class CreateMenuGroupCommandHandler : IRequestHandler<CreateMenuGroupCommand, bool>
{
    private readonly IMenuManagementRepository _managementRepository;

    public CreateMenuGroupCommandHandler(IMenuManagementRepository managementRepository)
    {
        _managementRepository = managementRepository;
    }

    public async Task<bool> Handle(CreateMenuGroupCommand request, CancellationToken cancellationToken)
    {
        var dtoList = request.DtoList;
        if (dtoList == null || dtoList.Count == 0)
            throw new CustomException("Список груп пустий");

        var menuId = dtoList.First().MenuId;

        var menu = await _managementRepository.GetMenuByIdAsync(menuId);

        var domainGroups = dtoList.Select(dto => new MenuGroup(dto.Name, dto.MenuId, dto.ParentId)).ToList();

        menu.CreateGroups(domainGroups);

        return await _managementRepository.CreateMenuGroupsAsync(menu.Groups.ToList());
    }
}