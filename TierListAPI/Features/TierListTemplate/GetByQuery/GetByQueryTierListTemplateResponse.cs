namespace TierListAPI.Features.TierListTemplate.GetByQuery;

public sealed record GetByQueryTierListTemplateResponse(
    List<Entities.Models.TierListTemplate> TierListTemplates
);