namespace TierListAPI.Features.TierListTemplate.Create;

public sealed record GetTierListTemplateResponse (
    Guid TemplateId,
    string Name,
    string Description
); 