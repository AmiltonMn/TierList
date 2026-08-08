using AutoMapper;
using UserModel = TierListAPI.Entities.Models.User;
using TierListAPI.DTOs;

namespace TierListAPI.Features.User.GetByUsername;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserModel, UserDto>();
    }
}