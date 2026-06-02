using MediatR;

namespace TierListAPI.Features.Tier.Delete;

public sealed record DeleteTierRequest
(
    Guid Id
) : IRequest<DeleteTierResponse>;