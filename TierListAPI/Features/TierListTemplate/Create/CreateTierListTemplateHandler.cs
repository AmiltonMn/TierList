using AutoMapper;
using MediatR;
using TierListAPI.Entities.Models;
using TierListAPI.Persistence.Repository;

namespace TierListAPI.Features.TierListTemplate.Create;
public class GetTierListTemplateHandler(
    ITierListTemplateRepository tierListTemplateRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IRequestHandler<GetTierListTemplateRequest, GetTierListTemplateResponse>
{
    private readonly ITierListTemplateRepository tierListTemplateRepository = tierListTemplateRepository;
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IMapper mapper = mapper;

    public async Task<GetTierListTemplateResponse> Handle(GetTierListTemplateRequest request, CancellationToken cancellationToken)
    {
        if(request.Name is null || request.Description is null)
            throw new Exception("Para criar um template, é necessário um nome e uma descrição!");
        
        if(request.Tags.Count == 0)
            throw new Exception("Selecione pelo menos uma tag para criar um template");

        var tierListTemplate = new Entities.Models.TierListTemplate
        {
            Name = request.Name,
            Description = request.Description,
            OwnerId = request.UserId,
            IsPrivate = request.IsPrivate,
        };

        tierListTemplate.Tiers.Add(new Tier
        {
            Label = "S",
            Color = "#FF7F7F",
            Position = 1,
            Points = 5,
            TierList = tierListTemplate
        });

        tierListTemplate.Tiers.Add(new Tier
        {
            Label = "A",
            Color = "#ffbf7f",
            Position = 2,
            Points = 4,
            TierList = tierListTemplate
        });

        tierListTemplate.Tiers.Add(new Tier
        {
            Label = "B",
            Color = "#ffdf7f",
            Position = 3,
            Points = 3,
            TierList = tierListTemplate
        });

        tierListTemplate.Tiers.Add(new Tier
        {
            Label = "C",
            Color = "#ffff7f",
            Position = 4,
            Points = 2,
            TierList = tierListTemplate
        });

        tierListTemplate.Tiers.Add(new Tier
        {
            Label = "D",
            Color = "#bfff7f",
            Position = 5,
            Points = 1,
            TierList = tierListTemplate
        });

        tierListTemplate.Tiers.Add(new Tier
        {
            Label = "E",
            Color = "#7fff7f",
            Position = 6,
            Points = 0,
            TierList = tierListTemplate
        });

        tierListTemplate.Tiers.Add(new Tier
        {
            Label = "F",
            Color = "#7fbfff",
            Position = 7,
            Points = -1,
            TierList = tierListTemplate
        });


        tierListTemplateRepository.Add(tierListTemplate);
        await unitOfWork.Save(cancellationToken);

        return mapper.Map<GetTierListTemplateResponse>(tierListTemplate);
    }
}