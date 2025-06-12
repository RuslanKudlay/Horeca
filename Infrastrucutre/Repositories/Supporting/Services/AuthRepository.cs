using Domain.Supporting.Auth.Entities;
using Infrastrucutre.Repositories.Supporting.Interfaces;

namespace Infrastrucutre.Repositories.Supporting.Services;

public class AuthRepository : IAuthRepository
{
    private AppDbContext _dbContext;

    public AuthRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> AddAsync(User user)
    {
        await _dbContext.Users.AddAsync(user);
        return await _dbContext.SaveChangesAsync() > 0;
    }
}