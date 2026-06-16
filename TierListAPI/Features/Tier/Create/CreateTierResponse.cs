namespace TierListAPI.Features.Tier.Create;

public sealed record CreateTierResponse(
    string Label,
    string Color,
    int Points,
    int Position
);