using MediatR;
using System.ComponentModel.DataAnnotations;

namespace TierListAPI.Features.TierListTemplate.Delete;

public sealed record DeleteTierListTemplateRequest(
    Guid TemplateId
) : IRequest<DeleteTierListTemplateResponse>;