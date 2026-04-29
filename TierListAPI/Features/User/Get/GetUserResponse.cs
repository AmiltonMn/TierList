using TierListAPI.Entities.Models;

namespace TierListAPI.Features.User.Get;

public sealed record GetUserResponse(
    string Name,
    string? Bio,
    string? ProfileImage,
    string? BannerImage,
    List<Entities.Models.TierListTemplate> CreatedTierLists,
    List<Entities.Models.TierListTemplate> AnsweredTierLists
);