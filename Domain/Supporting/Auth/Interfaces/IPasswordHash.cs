namespace Application.Supporting.Auth.Interfaces;

public interface IPasswordHasher
{
    string GetHash(string password);
}