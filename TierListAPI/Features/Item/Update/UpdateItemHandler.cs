using AutoMapper;
using MediatR;
using ItemModel = TierListAPI.Entities.Models.Item;
using TierListAPI.Persistence.Repository;
using TierListAPI.Common;
using TierListAPI.Common.ExceptionMessages;

namespace TierListAPI.Features.Item.Update;

public class UpdateItemHandler 
(
    IItemRepository itemRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IRequestHandler<UpdateItemRequest, UpdateItemResponse> {

    public async Task<UpdateItemResponse> Handle(UpdateItemRequest request, CancellationToken cancellationToken) 
    {
        ItemModel item = itemRepository.GetById(request.ItemId, cancellationToken).Result ?? throw new NotFoundException(ExceptionMessage.NotFound.Item);

        item.Name = request.Name;
        item.ItemImage = request.ItemImage;
        item.IsVertical = request.IsVertical;

        itemRepository.Update(item);

        await unitOfWork.Save(cancellationToken);

        return mapper.Map<UpdateItemResponse>(item);
    }
}
