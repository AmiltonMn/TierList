using MediatR;
using TagModel = TierListAPI.Entities.Models.Tag;

namespace TierListAPI.Features.TierListTemplate.Update;

public sealed record UpdateTierListTemplateRequest(
    Guid TemplateId,
    string Name,
    string Description,
    Guid UserId,
    bool IsPrivate,
    List<TagModel> Tags
) : IRequest<UpdateTierListTemplateResponse>;