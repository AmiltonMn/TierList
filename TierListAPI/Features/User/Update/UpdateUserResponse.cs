using TierListAPI.Entities.Models;

namespace TierListAPI.Features.User.Update;

public sealed record UpdateUserResponse(
    string Name,
    string? Bio,
    string? ProfileImage,
    string? BannerImage,
    List<Entities.Models.TierListTemplate> CreatedTierLists,
    List<Entities.Models.TierListTemplate> AnsweredTierLists
);