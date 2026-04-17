using TierListAPI.Entities.Models;

namespace TierListAPI.Features.User.Update;

public sealed record UpdateUserResponse(
    string Name,
    string? Bio,
    string? ProfileImage,
    string? BannerImage,
    List<TierListTemplate> CreatedTierLists,
    List<TierListTemplate> AnsweredTierLists
);