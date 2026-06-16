using AutoMapper;
using MediatR;
using TierListAPI.Persistence.Repository;

namespace TierListAPI.Features.UserAnswer.GetAllByTemplateAndUser;

public class GetAllByTemplateAndUserHandler
(
    IUserAnswerRepository userAnswerRepository,
    IMapper mapper
) : IRequestHandler<GetAllByTemplateAndUserRequest, GetAllByTemplateAndUserResponse>
{
    private readonly IUserAnswerRepository userAnswerRepository = userAnswerRepository;
    private readonly IMapper mapper = mapper;

    public async Task<GetAllByTemplateAndUserResponse> Handle(GetAllByTemplateAndUserRequest request, CancellationToken cancellationToken) 
    {
        var answerList = userAnswerRepository.GetAllByUserIdAndTemplateId(request.UserId, request.TemplateId);
        
        return mapper.Map<GetAllByTemplateAndUserResponse>(answerList);
    }
}
