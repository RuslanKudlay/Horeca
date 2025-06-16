namespace Application.Repositories.Supporting.User.Interfaces;

public interface IUserRepository
{
    Task<IReadOnlyList<Domain.Supporting.Auth.Entities.User>> GetAllAsync();
    Task<Domain.Supporting.Auth.Entities.User> GetByIdAsync(Guid userId);
    Task<bool> ChangePasswordAsync(Domain.Supporting.Auth.Entities.User user);
}