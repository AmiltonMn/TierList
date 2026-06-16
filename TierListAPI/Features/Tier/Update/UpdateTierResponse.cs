namespace TierListAPI.Features.Tier.Update;

public sealed record UpdateTierResponse(
    Guid Id,
    string Label,
    string Color,
    int Points,
    int Position
);