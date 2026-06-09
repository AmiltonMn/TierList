using TagModel = TierListAPI.Entities.Models.Tag;

namespace TierListAPI.Features.Tag.GetAll;

public sealed record GetAllTagResponse
(
    List<TagModel> Tags
);
