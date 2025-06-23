using Domain.Core.Menu;

namespace Application.Repositories.Core.MenuManagement;

public interface IMenuManagementRepository
{
    Task<bool> AddAsync(Menu menu);
}