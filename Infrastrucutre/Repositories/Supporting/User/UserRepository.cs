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
        return await _dbContext.Users.ToListAsync();
    }
}