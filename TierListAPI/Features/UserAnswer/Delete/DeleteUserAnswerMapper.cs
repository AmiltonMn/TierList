using AutoMapper;

namespace TierListAPI.Features.UserAnswer.Delete;

public class DeleteUserAnswerMapper : Profile
{
    public DeleteUserAnswerMapper() 
    {
        CreateMap<DeleteUserAnswerRequest, DeleteUserAnswerResponse>();
    }
}
