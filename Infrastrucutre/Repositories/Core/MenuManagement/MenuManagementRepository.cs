using Application.Repositories.Core.MenuManagement;
using Domain.Core.Menu;
using Microsoft.EntityFrameworkCore;

namespace Infrastrucutre.Repositories.Core.MenuManagement;

public class MenuManagementRepository : IMenuManagementRepository
{
    private readonly AppDbContext _dbContext;

    public MenuManagementRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> AddMenuAsync(Menu menu)
    {
        await _dbContext.Menus.AddAsync(menu);
        return await _dbContext.SaveChangesAsync() > 0;
    }

    public async Task<Menu> GetMenuByIdAsync(Guid Id)
    {
        return await _dbContext.Menus
            .AsNoTracking()
            .Include(menu => menu.Groups)
            .ThenInclude(group => group.Items)
            .FirstOrDefaultAsync(menu => menu.Id == Id);
    }

    public async Task<bool> CreateMenuGroupsAsync(List<MenuGroup> groups)
    {
        var menuId = groups.First().MenuId;

        var existingGroups = _dbContext.MenuGroups
            .Where(g => groups.Select(g => g.Id).Contains(g.Id) && g.MenuId == menuId)
            .ToList();
        
        if (existingGroups.Count == 0)
        {
            await _dbContext.MenuGroups.AddRangeAsync(groups);
            return await _dbContext.SaveChangesAsync() > 0;
        }

        return false;
    }

    public async Task<bool> UpdateMenuGroupsAsync(List<MenuGroup> groups)
    {
        _dbContext.MenuGroups.UpdateRange(groups);
        return await _dbContext.SaveChangesAsync() > 0;
    }
}