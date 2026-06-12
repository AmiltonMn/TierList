using MediatR;
using UserAnswerModel = TierListAPI.Entities.Models.UserAnswer;

namespace TierListAPI.Features.UserAnswer.Update;

public sealed record UpdateAnswerRequest
(
    UserAnswerModel Answer,
    Guid UserId,
    Guid TemplateId
) : IRequest<UpdateAnswerResponse>;
