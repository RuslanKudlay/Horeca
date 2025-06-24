using Domain.Core.Menu;

namespace Application.Repositories.Core.MenuManagement;

public interface IMenuManagementRepository
{
    Task<bool> AddMenuAsync(Menu menu);
    Task<Menu> GetMenuByIdAsync(Guid Id);
    Task<bool> CreateMenuGroupsAsync(List<MenuGroup> groups);
    Task<bool> UpdateMenuGroupsAsync(List<MenuGroup> groups);
}