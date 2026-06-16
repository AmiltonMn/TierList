using MediatR;

namespace TierListAPI.Features.Tier.Create;

public sealed record CreateTierRequest(
    string Label,
    string Color,
    int Position,
    int Points,
    Guid TierListId
) : IRequest<CreateTierResponse>;