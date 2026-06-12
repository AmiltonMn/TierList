using AutoMapper;

namespace TierListAPI.Features.Submission.GetByUser;

public class GetByUserMapper : Profile
{
    public GetByUserMapper() 
    {
        CreateMap<GetByUserRequest, GetByUserResponse>();
    }
}
