using Horeca.DTOs.Supporting.Auth;

namespace Application.Services.Supporting.User.Interfaces;

public interface IUserService
{
    Task<IReadOnlyList<Domain.Supporting.Auth.Entities.User>> GetAllAsync();
    
}