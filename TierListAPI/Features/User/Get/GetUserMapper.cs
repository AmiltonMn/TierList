using AutoMapper;

namespace TierListAPI.Features.User.Get;

public class GetUserMapper : Profile
{
    public GetUserMapper()
    {
        CreateMap<Entities.Models.User, GetUserResponse>();
    }
}