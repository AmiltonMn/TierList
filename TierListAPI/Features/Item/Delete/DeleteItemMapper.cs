using AutoMapper;

namespace TierListAPI.Features.Item.Delete;

public class DeleteItemMapper : Profile
{
    public DeleteItemMapper() 
    {
        CreateMap<DeleteItemRequest, DeleteItemResponse>();
    }
}
