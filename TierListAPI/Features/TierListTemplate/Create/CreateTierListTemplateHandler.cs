using AutoMapper;
using MediatR;
using TierModel = TierListAPI.Entities.Models.Tier;
using TierListAPI.Persistence.Repository;
using TierListAPI.Common;

namespace TierListAPI.Features.TierListTemplate.Create;
public class CrteateTierListTemplateHandler(
    ITierListTemplateRepository tierListTemplateRepository,
    ITierRepository tierRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IRequestHandler<CreateTierListTemplateRequest, CreateTierListTemplateResponse>
{
    private readonly ITierListTemplateRepository tierListTemplateRepository = tierListTemplateRepository;
    private readonly ITierRepository tierRepository = tierRepository;

    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IMapper mapper = mapper;

    public async Task<CreateTierListTemplateResponse> Handle(CreateTierListTemplateRequest request, CancellationToken cancellationToken)
    {
        if(request.Name is null || request.Description is null)
            throw new BadRequestException("Para criar um template, é necessário um nome e uma descrição!");
        
        if(request.Tags.Count == 0)
            throw new BadRequestException("Selecione pelo menos uma tag para criar um template");

        var tierListTemplate = new Entities.Models.TierListTemplate
        {
            Name = request.Name,
            Description = request.Description,
            BannerImage = "PlaceholderTierListBannerImage.png",
            OwnerId = request.UserId,
            IsPrivate = request.IsPrivate,
        };

        tierListTemplate.Tiers.Add(new TierModel
        {
            Label = "S",
            Color = "#FF7F7F",
            Position = 1,
            Points = 5,
            TierListTemplateId = tierListTemplate.Id
        });

        tierListTemplate.Tiers.Add(new TierModel
        {
            Label = "A",
            Color = "#ffbf7f",
            Position = 2,
            Points = 4,
            TierListTemplateId = tierListTemplate.Id
        });

        tierListTemplate.Tiers.Add(new TierModel
        {
            Label = "B",
            Color = "#ffdf7f",
            Position = 3,
            Points = 3,
            TierListTemplateId = tierListTemplate.Id
        });

        tierListTemplate.Tiers.Add(new TierModel
        {
            Label = "C",
            Color = "#ffff7f",
            Position = 4,
            Points = 2,
            TierListTemplateId = tierListTemplate.Id
        });

        tierListTemplate.Tiers.Add(new TierModel
        {
            Label = "D",
            Color = "#bfff7f",
            Position = 5,
            Points = 1,
            TierListTemplateId = tierListTemplate.Id
        });

        tierListTemplate.Tiers.Add(new TierModel
        {
            Label = "E",
            Color = "#7fff7f",
            Position = 6,
            Points = 0,
            TierListTemplateId = tierListTemplate.Id
        });

        tierListTemplate.Tiers.Add(new TierModel
        {
            Label = "F",
            Color = "#7fbfff",
            Position = 7,
            Points = -1,
            TierListTemplateId = tierListTemplate.Id
        });

        foreach (var tier in tierListTemplate.Tiers)
            tierRepository.Add(tier);

        tierListTemplateRepository.Add(tierListTemplate);
        await unitOfWork.Save(cancellationToken);

        return mapper.Map<CreateTierListTemplateResponse>(tierListTemplate);
    }
}