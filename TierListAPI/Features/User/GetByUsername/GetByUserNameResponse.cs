using TierListAPI.DTOs;

namespace TierListAPI.Features.User.GetByUsername;

public sealed record GetByUserNameResponse(
    List<UserDto> Users
);