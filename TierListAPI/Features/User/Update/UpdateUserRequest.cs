using MediatR;

namespace TierListAPI.Features.User.Update;

public sealed record UpdateUserRequest(
    Guid userId,
    string Name,
    string? Bio,
    string? ProfileImage,
    string? BannerImage
) : IRequest<UpdateUserResponse>;