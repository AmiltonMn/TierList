using MediatR;

namespace TierListAPI.Features.UserAnswer.Send;

public sealed record SendAnswersRequest
(
    Guid TemplateId
) : IRequest<SendAnswersResponse>;
