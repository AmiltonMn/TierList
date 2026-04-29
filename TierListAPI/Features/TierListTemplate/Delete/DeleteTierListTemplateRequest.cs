using MediatR;
using System.ComponentModel.DataAnnotations;

namespace TierListAPI.Features.TierListTemplate.Delete;

public sealed record DeleteTierListTemplateRequest(
    [Required]
    Guid TemplateId
) : IRequest<DeleteTierListTemplateResponse>;