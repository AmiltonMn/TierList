using AutoMapper;

namespace TierListAPI.Features.User.GetByUsername;

public class GetUserMapper : Profile
{
    public GetUserMapper()
    {
        CreateMap<Entities.Models.User, GetByUserNameResponse>();
    }
}