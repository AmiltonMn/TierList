using AutoMapper;

namespace TierListAPI.Features.UserAnswer.Send;

public class SendAnswersMapper : Profile
{
    public SendAnswersMapper() 
    {
        CreateMap<SendAnswersRequest, SendAnswersResponse>();
    }
}
