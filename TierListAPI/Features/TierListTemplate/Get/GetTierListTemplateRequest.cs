using MediatR;

namespace TierListAPI.Features.TierListTemplate.Get;

public sealed record GetByQueryTierListTemplateRequest(
    Guid TemplateId
) : IRequest<GetByQueryTierListTemplateResponse>;