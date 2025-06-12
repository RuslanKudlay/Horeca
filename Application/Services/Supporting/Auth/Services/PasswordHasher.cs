using System.Security.Cryptography;
using System.Text;
using Application.Supporting.Auth.Interfaces;

namespace Application.Supporting.Auth.Services;

public class PasswordHasher : IPasswordHasher
{
    public string GetHash(string password)
    {
        var bytes = new UTF8Encoding().GetBytes(password);
        byte[] hashBytes;
        using (var algorithm = new SHA512Managed())
        {
            hashBytes = algorithm.ComputeHash(bytes);
        }

        return Convert.ToBase64String(hashBytes);
    }
}