using MediatR;

namespace TierListAPI.Features.Item.Create;

public sealed record CreateItemRequest
(
    string Name,
    string ItemImage,
    bool IsVertical,
    Guid TierListId
) : IRequest<CreateItemResponse>;
