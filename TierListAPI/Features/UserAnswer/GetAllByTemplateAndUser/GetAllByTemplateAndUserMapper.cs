using AutoMapper;

namespace TierListAPI.Features.UserAnswer.GetAllByTemplateAndUser;

public class GetAllByTemplateAndUserMapper : Profile
{
    public GetAllByTemplateAndUserMapper() 
    {
        CreateMap<GetAllByTemplateAndUserRequest, GetAllByTemplateAndUserResponse>();
    }
}
