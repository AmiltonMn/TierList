using MediatR;

namespace TierListAPI.Features.TierListTemplate.GetByQuery;

public sealed record GetByQueryTierListTemplateRequest(
    int PageNumber,
    int PageSize,
    string? SearchByName,
    Guid? TagId,
    Guid? UserId,
    Guid LoggedUser
) : IRequest<GetByQueryTierListTemplateResponse>;