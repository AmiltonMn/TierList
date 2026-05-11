using UserModel = TierListAPI.Entities.Models.User;

namespace TierListAPI.Features.User.GetByUsername;

public sealed record GetByUserNameResponse(
    List<UserModel> Users
);