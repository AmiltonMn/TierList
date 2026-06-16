namespace TierListAPI.Services.JWT;

public sealed record JWTResponse (
    Guid UserId,
    string UserName
);