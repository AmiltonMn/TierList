using TierListTemplateModel = TierListAPI.Entities.Models.TierListTemplate;

namespace TierListAPI.Features.User.Get;

public sealed record GetUserResponse(
    string Name,
    string? Bio,
    string? ProfileImage,
    string? BannerImage,
    List<TierListTemplateModel> CreatedTierLists,
    List<TierListTemplateModel> AnsweredTierLists
);