using AutoMapper;
using MediatR;
using ItemModel = TierListAPI.Entities.Models.Item;
using TierListAPI.Persistence.Repository;

namespace TierListAPI.Features.Item.Create;

public class CreateItemHandler (
    IItemRepository itemRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IRequestHandler<CreateItemRequest, CreateItemResponse> {

    public async Task<CreateItemResponse> Handle(CreateItemRequest request, CancellationToken cancellationToken) 
    {
        if (itemRepository.GetItemsByName(request.Name, request.TierListTemplateId).Count > 0)
            throw new Exception("Já existe um item com esse nome.");

        if (request.ItemImage == "" || request.Name == "")
            throw new Exception("É necessário passar ao menos um nome e um link de imagem!");

        ItemModel item = new()
        {
            Name = request.Name,
            ItemImage = request.ItemImage,
            TierListTemplateId = request.TierListTemplateId,
            IsVertical = request.IsVertical,
        };

        itemRepository.Add(item);

        await unitOfWork.Save(cancellationToken);

        return mapper.Map<CreateItemResponse>(item);
    }
}
