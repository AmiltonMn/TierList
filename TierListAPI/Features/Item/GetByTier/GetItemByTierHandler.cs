using AutoMapper;
using MediatR;
using TierListAPI.Persistence.Repository;

namespace TierListAPI.Features.Item.GetByTier;

public class GetItemByTierhandler (
    IItemRepository itemRepository,
    IMapper mapper
) : IRequestHandler<GetItemByTierRequest, GetItemByTierResponse> {

    public async Task<GetItemByTierResponse> Handle(GetItemByTierRequest request, CancellationToken cancellationToken) 
    {
        var items = itemRepository.GetItemsByTier(request.TierId) ?? throw new Exception("Nenhum item foi encontrado para esse tier.");

        return mapper.Map<GetItemByTierResponse>(items);
    }
}
