using TierModel = TierListAPI.Entities.Models.Tier;

namespace TierListAPI.Features.Tier.GetAllByTier;

public sealed record GetAllByTierResponse
(
    List<TierModel> Tiers
);
