using MediatR;

namespace TierListAPI.Features.Tier.Update;

public sealed record UpdateTierRequest(
    Guid Id,
    string Color,
    int Position,
    int Points,
    Guid TierListId
) : IRequest<UpdateTierResponse>;