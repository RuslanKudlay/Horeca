using Domain.Supporting.Auth.Entities;
using Infrastrucutre.Repositories.Supporting.Interfaces;
using Microsoft.EntityFrameworkCore;

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

    public async Task<bool> ChangePasswordAsync(User user)
    {
        await _dbContext.Users.ExecuteUpdateAsync(setters => setters
                .SetProperty(u => u.Password, user.Password)
                .SetProperty(u => u.DateUpdated, user.DateUpdated));
        return true;
    }

    public async Task<bool> VerifyExistingUser(string email)
    {
        return await _dbContext.Users.AnyAsync(u => u.Email == email);
    }

    public async Task<User> GetByIdAsync(Guid userId)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == userId);
    }
}