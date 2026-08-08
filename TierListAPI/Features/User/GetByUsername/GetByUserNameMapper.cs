using AutoMapper;
using TierListAPI.DTOs;
using TierListAPI.Features.User.Get;

namespace TierListAPI.Features.User.GetByUsername;

public class GetByUserNameMapper : Profile
{
    public GetByUserNameMapper()
    {
        CreateMap<UserDto, GetUserResponse>();
    }
}