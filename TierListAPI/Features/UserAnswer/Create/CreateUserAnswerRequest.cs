using MediatR;

namespace TierListAPI.Features.UserAnswer.Create;

public sealed record CreateUserAnswerRequest
(
    Guid UserId,
    Guid TierListId,
    Guid ItemId,
    Guid TierId,
    Guid SubmissionId,
    string Comment,
    int Order
) : IRequest<CreateUserAnswerResponse>;
