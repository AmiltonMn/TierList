using MediatR;
using UserAnswerModel = TierListAPI.Entities.Models.UserAnswer;

namespace TierListAPI.Features.UserAnswer.Update;

public sealed record UpdateAnswerRequest
(
    UserAnswerModel Answer
) : IRequest<UpdateAnswerResponse>;
