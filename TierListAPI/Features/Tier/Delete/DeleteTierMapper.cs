using AutoMapper;

namespace TierListAPI.Features.Tier.Delete;

public class DeleteTierMapper : Profile
{
    public DeleteTierMapper() 
    {
        CreateMap<DeleteTierRequest, DeleteTierResponse>();
    }
}
