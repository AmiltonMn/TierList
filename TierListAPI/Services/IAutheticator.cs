using TierListAPI.Entities.Models;
using TierListAPI.Services.JWT;

namespace TierListAPI.Services;

public interface IAutheticator
{
    string GenerateUserToken(User user);
}
