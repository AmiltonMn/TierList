using TierListAPI.Entities.Models;
using AutoMapper;

namespace TierListAPI.Features.User.Update;

public class UpdateUserMapper : Profile
{
    public UpdateUserMapper()
    {
        CreateMap<Entities.Models.User, UpdateUserResponse>();
    }
}