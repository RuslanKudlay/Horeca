using Application.Supporting.Auth.Interfaces;
using Domain.Core;

namespace Domain.Supporting.Auth.Entities;

public class User : BaseEntity, IEntity
{
    public string? Name { get; }
    public string Email { get; }
    public string Password { get; protected set; }
    public string? Phone { get; }

    public User(string name, string email, string password, string phone)
    {
        Name = name;
        Email = email;
        Password = password;
        Phone = phone;
    }

    public void ChangePassword(string oldPassword, string newPassword, IPasswordHasher hasher)
    {
        var oldHash = hasher.GetHash(oldPassword);
        var newHash = hasher.GetHash(newPassword);

        if (oldHash != newHash)
        {
            Password = newHash;
        }

        SetUpdated();
    }
}