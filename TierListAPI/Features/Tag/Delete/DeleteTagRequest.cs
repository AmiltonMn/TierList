using MediatR;

namespace TierListAPI.Features.Tag.Delete;

public sealed record DeleteTagRequest
(
    Guid TagId
) : IRequest<DeleteTagResponse>;
