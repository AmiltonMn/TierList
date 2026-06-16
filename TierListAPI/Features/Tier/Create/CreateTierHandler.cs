using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using TierListAPI.Common;
using TierListAPI.Common.ExceptionMessages;
using TierListAPI.Persistence.Repository;
using TierModel = TierListAPI.Entities.Models.Tier;

namespace TierListAPI.Features.Tier.Create;

public class CreateTierHandler(
    ITierRepository tierRepository,
    ITierListTemplateRepository tierListTemplateRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IRequestHandler<CreateTierRequest, CreateTierResponse>
{
    public async Task<CreateTierResponse> Handle(CreateTierRequest request, CancellationToken cancellationToken) 
    {
        if (request.Label.IsWhiteSpace())
            throw new BadRequestException("Coloque ao menos uma letra no texto do tier.");

        if (request.TierListId == Guid.Empty)
            throw new NotFoundException(ExceptionMessage.NotFound.TierListTemplate);

        var tierListTemplate = await tierListTemplateRepository.GetById(request.TierListId, cancellationToken) ?? throw new NotFoundException(ExceptionMessage.NotFound.TierListTemplate);

        if (tierListTemplate.Tiers.Count >= 8)
            throw new BadRequestException("Você atingiu o máximo de tiers que uma Tier List pode ter.");

        var position = tierListTemplate.Tiers.LastOrDefault()?.Position + 1 ?? 0;

        var tier = new TierModel
        {
            Label = request.Label,
            Color = request.Color,
            Position = position,
            Points = (tierListTemplate.Tiers.Count) - request.Position,
            TierListTemplateId = request.TierListId
        };

        tierRepository.Add(tier);

        await unitOfWork.Save(cancellationToken);

        return mapper.Map<CreateTierResponse>(tier);
    }
}