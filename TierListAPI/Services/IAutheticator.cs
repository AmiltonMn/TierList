using TierListAPI.Entities.Models;

namespace TierListAPI.Services;

public interface IAutheticator
{
    string GenerateUserToken(User user);
    User ExtractToken(string token);
}
