using System.Text;
using TierListAPI.DTOs;
using TierListAPI.Entities.Models;

namespace TierListAPI.Services;

public class JWTHandler : IAutheticator
{
    private readonly IConfiguration _configuration;

    public JWTHandler(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GenerateUserToken(User user)
    {
        var tokenData = $"{user.Id}|{user.Name}|{DateTime.UtcNow.AddDays(1):yyyy-MM-dd HH:mm:ss}";
        var tokenBytes = Encoding.UTF8.GetBytes(tokenData);

        return Convert.ToBase64String(tokenBytes);
    }

    public JWTUser ExtractToken(string token)
    {
        try {
            var tokenBytes = Convert.FromBase64String(token);
            var tokenData = Encoding.UTF8.GetString(tokenBytes);
            var parts = tokenData.Split('|');

            if (parts.Length != 3)
                throw new Exception("Token JWT inválido");

            var userId = parts[0];
            var userName = parts[1];
            var expiryDate = DateTime.Parse(parts[2]);

            if (DateTime.UtcNow > expiryDate)
                throw new Exception("Seu token expirou! Faça login novamente");

            return new JWTUser
            (
                Id: Guid.Parse(userId),
                Name: userName
            );

        } catch {
            throw new Exception("Token JWT inválido");
        }
    }
}
