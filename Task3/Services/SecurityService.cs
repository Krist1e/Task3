using System.Security.Cryptography;
using System.Text;

namespace Task3.Services;

public class SecurityService
{
    private readonly RandomNumberGenerator _generator = RandomNumberGenerator.Create();

    public string GenerateKey()
    {
        var bytes = new byte[16];
        _generator.GetBytes(bytes);
        return BitConverter.ToString(bytes).Replace("-", "");
    }

    public string GenerateHmac(string key, string message)
    {
        var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(key));
        var hmacHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(message));
        return BitConverter.ToString(hmacHash).Replace("-", "");
    }
}