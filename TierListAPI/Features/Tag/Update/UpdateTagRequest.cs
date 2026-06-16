using MediatR;
using System.Reflection.Metadata;

namespace TierListAPI.Features.Tag.Update;

public sealed record UpdateTagRequest
(
    Guid TagId,
    string Label,
    string Color
) : IRequest<UpdateTagResponse>;
