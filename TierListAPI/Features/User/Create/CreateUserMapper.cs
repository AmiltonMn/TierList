using TierListAPI.Entities.Models;
using AutoMapper;

namespace TierListAPI.Features.User.Create;

public class CreateUserMapper : Profile
{
    public CreateUserMapper()
    {
        CreateMap<CreateUserRequest, CreateUserResponse>();
    }
}