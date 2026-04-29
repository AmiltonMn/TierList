using MediatR;
using System.ComponentModel.DataAnnotations;
using TierListAPI.Entities.Models;

namespace TierListAPI.Features.TierListTemplate.Update;

public sealed record UpdateTierListTemplateRequest(
    [Required]
    Guid TemplateId,
    [Required]
    [MaxLength(100), MinLength(5)]
    string Name,
    [Required]
    [MaxLength(500), MinLength(10)]
    string Description,
    Guid UserId,
    bool IsPrivate,
    List<Tag> Tags
) : IRequest<UpdateTierListTemplateResponse>;