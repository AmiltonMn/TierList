using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using TierListAPI.Entities.Models;
using TierListAPI.Services.JWT;

namespace TierListAPI.Services;

public class JWTHandler (IConfiguration configuration) : IAutheticator
{
    public string GenerateUserToken(User user)
    {
        var secret = configuration["Jwt:Secret"]!;
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new []
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Name)
        };

        var token = new JwtSecurityToken(
            issuer: configuration["Jwt:Issuer"],
            audience: configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddDays(1),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public JWTResponse ExtractToken(string token)
    {
        try {
            var tokenBytes = Convert.FromBase64String(token);
            var tokenData = Encoding.UTF8.GetString(tokenBytes);
            var parts = tokenData.Split('|');

            if (parts.Length != 3)
                throw new Exception("Token JWT inválido");

            Guid userId = Guid.Parse(parts[0]);
            var userName = parts[1];
            var expiryDate = DateTime.Parse(parts[2]);

            if (DateTime.UtcNow > expiryDate)
                throw new Exception("Seu token expirou! Faça login novamente");

            return new JWTResponse(userId, userName);

        } catch {
            throw new Exception("Token JWT inválido");
        }
    }
}
