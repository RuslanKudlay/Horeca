using Domain.Supporting.Auth.Entities;

namespace Infrastrucutre.Repositories.Supporting.Interfaces;

public interface IAuthRepository
{
    Task<bool> AddAsync(User user);
    Task<bool> ChangePasswordAsync(User user);
    Task<bool> VerifyExistingUser(string email);
    Task<User> GetByIdAsync(Guid userId);
}