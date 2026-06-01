using AutoMapper;

namespace TierListAPI.Features.Tier.Update;

public class UpdateTierMapper : Profile
{ 
    public UpdateTierMapper()
    {
        CreateMap<UpdateTierRequest, UpdateTierResponse>();
    }
}