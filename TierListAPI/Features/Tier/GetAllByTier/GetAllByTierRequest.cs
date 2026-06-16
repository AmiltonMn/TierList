using MediatR;

namespace TierListAPI.Features.Tier.GetAllByTier;

public sealed record GetAllByTierRequest
(
    Guid TierListId
) : IRequest<GetAllByTierResponse>;
