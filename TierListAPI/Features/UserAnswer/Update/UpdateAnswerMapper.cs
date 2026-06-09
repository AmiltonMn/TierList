using AutoMapper;

namespace TierListAPI.Features.UserAnswer.Update;

public class UpdateAnswerMapper : Profile
{
    public UpdateAnswerMapper() 
    {
        CreateMap<UpdateAnswerRequest, UpdateAnswerResponse>();
    }
}
