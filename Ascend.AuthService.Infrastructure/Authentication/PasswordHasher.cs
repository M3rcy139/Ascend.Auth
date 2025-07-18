using System.Text;
using Ascend.AuthService.Business.Interfaces.Authentication;

namespace Ascend.AuthService.Infrastructure.Authentication;

public class PasswordHasher : IPasswordHasher
{
    public byte[] Generate(string password)
    {
        var hashed = BCrypt.Net.BCrypt.EnhancedHashPassword(password);
        return Encoding.UTF8.GetBytes(hashed); 
    }

    public bool Verify(string password, byte[] hashedPassword)
    {
        var hashStr = Encoding.UTF8.GetString(hashedPassword);
        return BCrypt.Net.BCrypt.EnhancedVerify(password, hashStr);
    }
}