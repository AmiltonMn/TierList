using AutoMapper;
using MediatR;
using TierListAPI.Common;
using TierListAPI.Common.ExceptionMessages;
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
            throw new BadRequestException("Item inválido.");

        var item = await itemRepository.GetById(request.ItemId, cancellationToken) ?? throw new NotFoundException(ExceptionMessage.NotFound.Item);

        itemRepository.Delete(item);

        await unitOfWork.Save(cancellationToken);

        return mapper.Map<DeleteItemResponse>(item);
    }
}
