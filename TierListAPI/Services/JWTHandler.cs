using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using TierListAPI.DTOs;
using TierListAPI.Entities.Models;

namespace TierListAPI.Services;

public class JWTHandler : IAutheticator
{
    private const string SecretKey = "%IUojN$JKjunJKI47y$HThrfHGF56t5fgh$F";

    public string GenerateUserToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(SecretKey);

        var claims = new[]
        {
            new Claim("id", user.Id.ToString()),
            new Claim("name", user.Name)
        };

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddDays(1),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature
            )
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    public JWTUser ExtractToken(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(SecretKey);

        try
        {
            var parameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ClockSkew = TimeSpan.Zero
            };

            var principal = tokenHandler.ValidateToken(token, parameters, out _);

            var userId = principal.FindFirst("id")?.Value;
            var userName = principal.FindFirst("name")?.Value;

            return new JWTUser(
                Id: Guid.Parse(userId!),
                Name: userName!
            );
        }
        catch
        {
            throw new Exception("Token inválido ou expirado");
        }
    }
}