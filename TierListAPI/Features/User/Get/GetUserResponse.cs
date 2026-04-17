using TierListAPI.Entities.Models;

namespace TierListAPI.Features.User.Get;

public sealed record GetUserResponse(
    string Name,
    string? Bio,
    string? ProfileImage,
    string? BannerImage,
    List<TierListTemplate> CreatedTierLists,
    List<TierListTemplate> AnsweredTierLists
);