namespace TierListAPI.Features.TierListTemplate.Delete;

public sealed record DeleteTierListTemplateResponse(
    Guid TemplateId,
    DateTime DeleteDate
);