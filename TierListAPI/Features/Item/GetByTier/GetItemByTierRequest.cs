using MediatR;

namespace TierListAPI.Features.Item.GetByTier;

public sealed record GetItemByTierRequest
(
    Guid TierId
) : IRequest<GetItemByTierResponse>;