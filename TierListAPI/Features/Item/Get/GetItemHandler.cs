using AutoMapper;
using MediatR;
using TierListAPI.Common;
using TierListAPI.Common.ExceptionMessages;
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
            throw new BadRequestException("Item inválido.");

        var item = itemRepository.GetById(request.ItemId, cancellationToken) ?? throw new NotFoundException(ExceptionMessage.NotFound.Item);

        return mapper.Map<GetItemResponse>(item);
    }
}
