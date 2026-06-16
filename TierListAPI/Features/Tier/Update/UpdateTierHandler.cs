using AutoMapper;
using MediatR;
using TierListAPI.Common;
using TierListAPI.Common.ExceptionMessages;
using TierListAPI.Persistence.Repository;

namespace TierListAPI.Features.Tier.Update;

public class UpdateTierHandler(
    ITierRepository tierRepository,
    ITierListTemplateRepository tierListTemplateRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IRequestHandler<UpdateTierRequest, UpdateTierResponse>
{ 
    private readonly ITierRepository tierRepository = tierRepository;
    private readonly ITierListTemplateRepository tierListTemplateRepository = tierListTemplateRepository;
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IMapper mapper = mapper;

    public async Task<UpdateTierResponse> Handle(UpdateTierRequest request, CancellationToken cancellationToken) 
    {
        if (string.IsNullOrWhiteSpace(request.Label))
            throw new BadRequestException("É necessário colocar um nome para o tier.");

        var tier = await tierRepository.GetById(request.Id, cancellationToken) ?? throw new NotFoundException(ExceptionMessage.NotFound.Tier);

        var tierListTemplate = await tierListTemplateRepository.GetById(request.TierListId, cancellationToken) ?? throw new NotFoundException(ExceptionMessage.NotFound.TierListTemplate);

        tier.Color = request.Color;
        tier.Label = request.Label;

        if (request.Position != tier.Position)
        {
            var tierToBeReplaced = tierListTemplate.Tiers.Find(t => t.Position == request.Position);

            if (tierToBeReplaced != null)
            {
                (tierToBeReplaced.Position, tier.Position) = (tier.Position, tierToBeReplaced.Position);
                (tierToBeReplaced.Points, tier.Points) = (tier.Points, tierToBeReplaced.Points);

                tierRepository.Update(tierToBeReplaced);
            }
        }

        tierRepository.Update(tier);
        await unitOfWork.Save(cancellationToken);

        return mapper.Map<UpdateTierResponse>(tier);
    }
}