using Application.Repositories.Supporting.User.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastrucutre.Repositories.Supporting.User;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _dbContext;

    public UserRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IReadOnlyList<Domain.Supporting.Auth.Entities.User>> GetAllAsync()
    {
        return await _dbContext.Users.AsNoTracking().ToListAsync();
    }

    public async Task<Domain.Supporting.Auth.Entities.User> GetByIdAsync(Guid userId)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == userId);
    }
    
    public async Task<bool> ChangePasswordAsync(Domain.Supporting.Auth.Entities.User user)
    {
        await _dbContext.Users.ExecuteUpdateAsync(setters => setters
            .SetProperty(u => u.Password, user.Password)
            .SetProperty(u => u.DateUpdated, user.DateUpdated));
        return true;
    }
}