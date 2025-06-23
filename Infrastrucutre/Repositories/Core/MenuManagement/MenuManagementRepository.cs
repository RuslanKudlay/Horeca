using Application.Repositories.Core.MenuManagement;
using Domain.Core.Menu;

namespace Infrastrucutre.Repositories.Core.MenuManagement;

public class MenuManagementRepository : IMenuManagementRepository
{
    private readonly AppDbContext _dbContext;

    public MenuManagementRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> AddAsync(Menu menu)
    {
        await _dbContext.Menus.AddAsync(menu);
        return await _dbContext.SaveChangesAsync() > 0;
    }
}