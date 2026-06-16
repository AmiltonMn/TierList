using MediatR;

namespace TierListAPI.Features.UserAnswer.Delete;

public sealed record DeleteUserAnswerRequest
(
    Guid AnswerId
) : IRequest<DeleteUserAnswerResponse>;
