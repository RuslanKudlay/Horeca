using Domain.Core;

namespace Domain.Supporting.Auth.Entities;

public class User : BaseEntity, IEntity
{
    public string? Name { get; }
    public string Email { get; }
    public string Password { get; }
    public string? Phone { get; }

    public User(string name, string email, string password, string phone)
    {
        Name = name;
        Email = email;
        Password = password;
        Phone = phone;
    }
}