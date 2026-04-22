using System.ComponentModel.DataAnnotations;
using MediatR;
using TierListAPI.Entities.Models;

namespace TierListAPI.Features.TierListTemplate.Create;

public sealed record CreateTierListTemplateRequest(
    [Required]
    [MaxLength(100), MinLength(5)]
    string Name,
    [Required]
    [MaxLength(500), MinLength(10)]
    string Description,
    Guid UserId,
    bool IsPrivate,
    List<Tag> Tags
) : IRequest<CreateTierListTemplateResponse>;