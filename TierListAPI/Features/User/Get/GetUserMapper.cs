using AutoMapper;
using UserModel = TierListAPI.Entities.Models.User;

namespace TierListAPI.Features.User.Get;

public class GetUserMapper : Profile
{
    public GetUserMapper()
    {
        CreateMap<UserModel, GetUserResponse>();
    }
}