using MediatR;

namespace TierListAPI.Features.User.Create;

public sealed record CreateUserRequest(
    string Name,
    string Password,
    string? Bio,
    string? ProfileImage,
    string? BannerImage
) : IRequest<CreateUserResponse>;