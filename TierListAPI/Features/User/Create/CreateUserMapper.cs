using UserModel = TierListAPI.Entities.Models.User;
using AutoMapper;

namespace TierListAPI.Features.User.Create;

public class CreateUserMapper : Profile
{
    public CreateUserMapper()
    {
        CreateMap<UserModel, CreateUserResponse>();
    }
}