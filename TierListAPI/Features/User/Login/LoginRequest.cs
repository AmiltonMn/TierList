using MediatR;

namespace TierListAPI.Features.User.Login;

public sealed record LoginRequest
(
    string Username,
    string Password
) : IRequest<LoginResponse>;
