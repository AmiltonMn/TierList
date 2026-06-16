using MediatR;

namespace TierListAPI.Features.Tag.GetAll;

public sealed record GetAllTagRequest : IRequest<GetAllTagResponse>;