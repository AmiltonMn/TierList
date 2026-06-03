using MediatR;

namespace TierListAPI.Features.UserAnswer.GetAllByTemplateAndUser;

public sealed record GetAllByTemplateAndUserRequest
(
    Guid TemplateId,
    Guid UserId
): IRequest<GetAllByTemplateAndUserResponse>;