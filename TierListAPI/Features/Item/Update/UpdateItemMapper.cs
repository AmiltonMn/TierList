using AutoMapper;

namespace TierListAPI.Features.Item.Update;

public class UpdateItemMapper : Profile
{
    public UpdateItemMapper() 
    {
        CreateMap<UpdateItemRequest, UpdateItemResponse>();
    }
}
