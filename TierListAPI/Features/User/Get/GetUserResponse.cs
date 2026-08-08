using TierListTemplateModel = TierListAPI.Entities.Models.TierListTemplate;
using SumbissionModel = TierListAPI.Entities.Models.TierListSubmission;

namespace TierListAPI.Features.User.Get;

public sealed record GetUserResponse(
    string Name,
    string? Bio,
    string? ProfileImage,
    string? BannerImage,
    List<TierListTemplateModel>? CreatedTierLists,
    List<SumbissionModel>? AnsweredTierLists
);