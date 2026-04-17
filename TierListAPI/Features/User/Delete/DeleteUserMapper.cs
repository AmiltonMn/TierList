using AutoMapper;

namespace TierListAPI.Features.User.Delete;

public class DeleteUserMapper : Profile
{
    public DeleteUserMapper()
    {
        CreateMap<Entities.Models.User, DeleteUserResponse>();
    }
}