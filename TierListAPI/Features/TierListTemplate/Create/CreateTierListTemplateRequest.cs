using System.ComponentModel.DataAnnotations;
using MediatR;
using TagModel = TierListAPI.Entities.Models.Tag;

namespace TierListAPI.Features.TierListTemplate.Create;

public sealed record CreateTierListTemplateRequest(
    string Name,
    string Description,
    Guid UserId,
    bool IsPrivate,
    List<TagModel> Tags
) : IRequest<CreateTierListTemplateResponse>;