using AutoMapper;
using MediatR;
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
    private readonly ITierRepository tierRepository = tierRepository;
    private readonly ITierListTemplateRepository tierListTemplateRepository = tierListTemplateRepository;
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IMapper mapper = mapper;

    public async Task<CreateTierResponse> Handle(CreateTierRequest request, CancellationToken cancellationToken) 
    {
        if (request.Label.IsWhiteSpace())
            throw new Exception("Por favor, coloque ao menos uma letra no texto do tier.");

        if (request.TierListId == Guid.Empty)
            throw new Exception("Tier List inválido.");

        var tierListTemplate = tierListTemplateRepository.GetById(request.TierListId, cancellationToken) ?? throw new Exception("Tier List não encontrado");

        if (tierListTemplate.Result == null)
            throw new Exception("Erro ao buscar Tier List");

        if (tierListTemplate.Result.Tiers.Count >= 8)
            throw new Exception("Você atingiu o máximo de tiers que uma Tier List pode ter.");

        var position = tierListTemplate.Result.Tiers.LastOrDefault()?.Position + 1 ?? 0;

        var tier = new TierModel
        {
            Label = request.Label,
            Color = request.Color,
            Position = position,
            Points = (tierListTemplate.Result.Tiers.Count) - request.Position,
            TierListId = request.TierListId
        };

        tierRepository.Add(tier);

        await unitOfWork.Save(cancellationToken);

        return mapper.Map<CreateTierResponse>(tier);
    }
}