using MediatR;

namespace TierListAPI.Features.Submission.GetByUser;

public sealed record GetByUserRequest
(
    Guid UserId
) : IRequest<GetByUserResponse>;
