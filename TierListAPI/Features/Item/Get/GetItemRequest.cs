using MediatR;

namespace TierListAPI.Features.Item.Get;

public sealed record GetItemRequest
(
    Guid ItemId
) : IRequest<GetItemResponse>;
