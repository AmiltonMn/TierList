using AutoMapper;
using MediatR;
using ItemModel = TierListAPI.Entities.Models.Item;
using TierListAPI.Persistence.Repository;

namespace TierListAPI.Features.Item.Update;

public class UpdateItemHandler 
(
    IItemRepository itemRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IRequestHandler<UpdateItemRequest, UpdateItemResponse> {

    public async Task<UpdateItemResponse> Handle(UpdateItemRequest request, CancellationToken cancellationToken) 
    {
        
    }
}
