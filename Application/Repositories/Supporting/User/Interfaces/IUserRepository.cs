namespace Application.Repositories.Supporting.User.Interfaces;

public interface IUserRepository
{
    Task<IReadOnlyList<Domain.Supporting.Auth.Entities.User>> GetAllAsync();
}