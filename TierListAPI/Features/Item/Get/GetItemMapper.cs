using AutoMapper;

namespace TierListAPI.Features.Item.Get;

public class GetItemMapper : Profile
{
    public GetItemMapper() 
    {
        CreateMap<GetItemRequest, GetItemResponse>();
    }
}
