using MediatR;

namespace TierListAPI.Features.Item.Update;

public sealed record UpdateItemRequest
(
    Guid ItemId,
    string Name,
    string ItemImage,
    bool IsVertical,
    Guid TierListTemplateId
) : IRequest<UpdateItemResponse>;