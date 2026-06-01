using AutoMapper;
using MediatR;
using TierListAPI.Persistence.Repository;

namespace TierListAPI.Features.Tier.Create;

public class CreateTierHandler(
    ITierRepository tierRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IRequestHandler<CreateTierRequest, CreateTierResponse>
{
    private readonly ITierRepository tierRepository = tierRepository;
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IMapper mapper = mapper;

    public async Task<CreateTierResponse> Handle(CreateTierRequest request, CancellationToken cancellationToken) 
    {
        if (request.Label.IsWhiteSpace())
            throw new Exception("Por favor, coloque ao menos uma letra no texto do tier.");

        var tier = new Entities.Models.Tier
        {
            Label = request.Label,
            Color = request.Color,
            Position = request.Position,
            Points = request.Points,
            TierListId = request.TierListId
        };

        tierRepository.Add(tier);
        await unitOfWork.Save(cancellationToken);

        return mapper.Map<CreateTierResponse>(tier);
    }
}