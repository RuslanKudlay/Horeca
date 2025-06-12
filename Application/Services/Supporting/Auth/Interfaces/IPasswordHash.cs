namespace Application.Supporting.Auth.Interfaces;

public interface IPasswordHash
{
    string GetHash(string password);
}