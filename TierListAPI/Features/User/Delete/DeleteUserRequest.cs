using MediatR;

namespace TierListAPI.Features.User.Delete;

public sealed record DeleteUserRequest(
    Guid Id
) : IRequest<DeleteUserResponse>;