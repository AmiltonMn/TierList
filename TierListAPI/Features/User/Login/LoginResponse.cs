namespace TierListAPI.Features.User.Login;

public sealed record LoginResponse
(
    Guid UserId,
    string Token
);