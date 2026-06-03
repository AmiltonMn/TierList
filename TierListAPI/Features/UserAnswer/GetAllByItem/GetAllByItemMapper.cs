using AutoMapper;

namespace TierListAPI.Features.UserAnswer.GetAllByItem;

public class GetAllByTierAndUserMapper : Profile
{
    public GetAllByTierAndUserMapper() 
    {
        CreateMap<GetAllByTierAndUserRequest, GetAllByTierAndUserResponse>();
    }
}
