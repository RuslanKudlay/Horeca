using Application.Eceptions;
using Application.Repositories.Core.MenuManagement;
using AutoMapper;
using Domain.Core.Menu;
using Horeca.DTOs.Core.MenuManagement;
using MediatR;

namespace Application.Commands.Core.MenuManagement;

public class UpdateMenuGroupCommandHandler : IRequestHandler<UpdateMenuGroupCommand, bool>
{
    private readonly IMenuManagementRepository _managementRepository;
    private readonly IMapper _mapper;

    public UpdateMenuGroupCommandHandler(IMenuManagementRepository managementRepository, IMapper mapper)
    {
        _managementRepository = managementRepository;
        _mapper = mapper;
    }

    public async Task<bool> Handle(UpdateMenuGroupCommand request, CancellationToken cancellationToken)
    {
        var dtoList = request.DtoList;
        if (dtoList == null || dtoList.Count == 0)
            throw new CustomException("Список груп пустий");

        var menuId = dtoList.First().MenuId;
        var menu = await _managementRepository.GetMenuByIdAsync(menuId);

        var groupsForUpdate = _mapper.Map<List<MenuGroup>>(dtoList);
        menu.UpdateGroups(groupsForUpdate);
        
        return await _managementRepository.UpdateMenuGroupsAsync(menu.Groups.ToList());

    }
}