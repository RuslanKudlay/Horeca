using Domain.Supporting.Auth.Entities;

namespace Infrastrucutre.Repositories.Supporting.Interfaces;

public interface IAuthRepository
{
    Task<bool> AddAsync(User user);
}