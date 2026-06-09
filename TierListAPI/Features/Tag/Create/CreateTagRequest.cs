using MediatR;

namespace TierListAPI.Features.Tag.Create;

public sealed record CreateTagRequest
(
    string Label,
    string Color
) : IRequest<CreateTagResponse>;
