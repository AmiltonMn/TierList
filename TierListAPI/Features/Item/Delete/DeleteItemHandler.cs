using AutoMapper;
using MediatR;
using TierListAPI.Persistence.Repository;

namespace TierListAPI.Features.Item.Delete;

public class DeleteItemHandler 
(
    IItemRepository itemRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IRequestHandler<DeleteItemRequest, DeleteItemResponse> {

    public async Task<DeleteItemResponse> Handle(DeleteItemRequest request, CancellationToken cancellationToken)
    {
        if (request.ItemId == Guid.Empty)
            throw new Exception("Item inválido.");

        var item = await itemRepository.GetById(request.ItemId, cancellationToken) ?? throw new Exception("Item não encontrado.");

        itemRepository.Delete(item);

        await unitOfWork.Save(cancellationToken);

        return mapper.Map<DeleteItemResponse>(item);
    }
}
