using MediatR;

namespace TierListAPI.Features.Item.GetAllByTemplate;

public sealed record GetAllByTemplateRequest
(
    Guid TemplateId
) : IRequest<GetAllByTemplateResponse>;
