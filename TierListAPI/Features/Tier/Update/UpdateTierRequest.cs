using MediatR;

namespace TierListAPI.Features.Tier.Update;

public sealed record UpdateTierRequest(
    Guid Id,
    string Color,
    string Label,
    int Position,
    int Points,
    Guid TierListId
) : IRequest<UpdateTierResponse>;