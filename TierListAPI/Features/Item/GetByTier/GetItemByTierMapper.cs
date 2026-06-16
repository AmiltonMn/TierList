using AutoMapper;

namespace TierListAPI.Features.Item.GetByTier;

public class GetItemByTierMapper : Profile
{
    public GetItemByTierMapper() 
    {
        CreateMap<GetItemByTierRequest, GetItemByTierResponse>();
    }
}
