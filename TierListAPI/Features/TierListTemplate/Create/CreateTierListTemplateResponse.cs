namespace TierListAPI.Features.TierListTemplate.Create;

public sealed record CreateTierListTemplateResponse (
    Guid TemplateId,
    string Name,
    string Description
); 