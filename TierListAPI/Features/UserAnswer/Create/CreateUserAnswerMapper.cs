using AutoMapper;

namespace TierListAPI.Features.UserAnswer.Create;

public class CreateUserAnswerMapper : Profile
{
    public CreateUserAnswerMapper() 
    {
        CreateMap<CreateUserAnswerRequest, CreateUserAnswerResponse>();
    }
}
