using MediatR;

namespace TierListAPI.Features.User.GetByUsername;

public sealed record GetByUserNameRequest(string Name) : IRequest<GetByUserNameResponse>;