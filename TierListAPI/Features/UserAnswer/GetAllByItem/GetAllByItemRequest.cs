using MediatR;

namespace TierListAPI.Features.UserAnswer.GetAllByItem;

public sealed record GetAllByTierAndUserRequest
(
    Guid ItemId
): IRequest<GetAllByTierAndUserResponse>;