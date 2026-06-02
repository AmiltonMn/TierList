using AutoMapper;

namespace TierListAPI.Features.Tier.GetAllByTier;

public class GetAllByTierMapper : Profile
{
    public GetAllByTierMapper() 
    {
        CreateMap<GetAllByTierRequest, GetAllByTierResponse>();
    }
}
