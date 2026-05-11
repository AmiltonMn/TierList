using MediatR;

namespace TierListAPI.Features.User.Get;

public sealed record GetUserRequest(Guid UserId) : IRequest<GetUserResponse>;