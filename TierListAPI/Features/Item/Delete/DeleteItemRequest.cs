using MediatR;

namespace TierListAPI.Features.Item.Delete;

public sealed record DeleteItemRequest
(
    Guid ItemId
) : IRequest<DeleteItemResponse>;
