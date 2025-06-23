using Application.Repositories.Core.MenuManagement;
using Domain.Core.Menu;
using MediatR;

namespace Application.Commands.Core.MenuManagement;

public class CreateMenuCommandHadler : IRequestHandler<CreateMenuCommand, bool>
{
    private readonly IMenuManagementRepository _managementRepository;

    public CreateMenuCommandHadler(IMenuManagementRepository managementRepository)
    {
        _managementRepository = managementRepository;
    }

    public async Task<bool> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
    {
        var dto = request.dto;
        var menu = new Menu(dto.Name);
        return await _managementRepository.AddAsync(menu);
    }
}