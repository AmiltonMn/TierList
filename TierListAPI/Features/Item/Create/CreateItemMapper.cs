using AutoMapper;

namespace TierListAPI.Features.Item.Create;

public class CreateItemMapper : Profile
{
    public CreateItemMapper() 
    {
        CreateMap<CreateItemRequest, CreateItemResponse>();
    }
}
