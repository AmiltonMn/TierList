namespace TierListAPI.Features.TierListTemplate.Update;

public sealed record UpdateTierListTemplateResponse(
    Guid TemplateId,
    DateTime UpdateDate
);