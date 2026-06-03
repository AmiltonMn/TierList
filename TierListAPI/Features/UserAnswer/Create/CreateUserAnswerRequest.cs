using MediatR;

namespace TierListAPI.Features.UserAnswer.Create;

public sealed record CreateUserAnswerRequest
(
    Guid UserId,
    Guid TierListId,
    Guid ItemId,
    Guid TierId,
    string Comment,
    int Order
) : IRequest<CreateUserAnswerResponse>;
