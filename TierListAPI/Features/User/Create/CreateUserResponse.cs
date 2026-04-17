namespace TierListAPI.Features.User.Create;

public sealed record CreateUserResponse(
    string Name,
    string? Bio,
    string? ProfileImage,
    string? BannerImage
);