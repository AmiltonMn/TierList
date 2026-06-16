using AutoMapper;

namespace TierListAPI.Features.Tier.Create;

public class CreateTierMapper : Profile
{
    public CreateTierMapper()
    {
        CreateMap<CreateTierRequest, CreateTierResponse>();
    }
}