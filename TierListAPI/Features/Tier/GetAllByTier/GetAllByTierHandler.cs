using AutoMapper;
using MediatR;
using TierListAPI.Common;
using TierListAPI.Common.ExceptionMessages;
using TierListAPI.Persistence.Repository;

namespace TierListAPI.Features.Tier.GetAllByTier;

public class GetAllByTierHandler
(
    ITierRepository tierRepository,
    IMapper mapper
) : IRequestHandler<GetAllByTierRequest, GetAllByTierResponse>
{
    private readonly ITierRepository tierRepository = tierRepository;
    private readonly IMapper mapper = mapper;

    public async Task<GetAllByTierResponse> Handle(GetAllByTierRequest request, CancellationToken cancellationToken)
    {
        if (request.TierListId == Guid.Empty)
            throw new BadRequestException("TierListId inválido.");

        var tiers = tierRepository.GetTiersByTierListTemplateId(request.TierListId);

        if (tiers.Count == 0)
            throw new NotFoundException(ExceptionMessage.NotFound.Tier);

        return mapper.Map<GetAllByTierResponse>(tiers);
    }
}