using MediatR;
using TierListAPI.Entities.Models;

namespace TierListAPI.Features.TierListTemplate.Delete;

public sealed record DeleteTierListTemplateRequest(
    [Required]
    Guid TemplateId
) : IRequest<CreateTierListTemplateResponse>;