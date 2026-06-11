using AutoMapper;
using MediatR;
using TierListAPI.Persistence.Repository;

namespace TierListAPI.Features.Item.Get;

public class GetItemHandler 
(
    IItemRepository itemRepository,
    IMapper mapper
) : IRequestHandler<GetItemRequest, GetItemResponse> {

    public async Task<GetItemResponse> Handle(GetItemRequest request, CancellationToken cancellationToken) 
    {
        if (request.ItemId == Guid.Empty)
            throw new Exception("Item inválido.");

        var item = itemRepository.GetById(request.ItemId, cancellationToken) ?? throw new Exception("Item não encontrado.");

        return mapper.Map<GetItemResponse>(item);
    }
}
