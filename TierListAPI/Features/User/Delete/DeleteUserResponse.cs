using UserModel = TierListAPI.Entities.Models.User;

namespace TierListAPI.Features.User.Delete;

public sealed record DeleteUserResponse(
    UserModel User
);