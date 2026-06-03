using AutoMapper;
using MediatR;
using TierListAPI.Persistence.Repository;

namespace TierListAPI.Features.UserAnswer.GetAllByItem;

public class GetAllByTierAndUserHandler
(
    IUserAnswerRepository userAnswerRepository,
    IMapper mapper
) : IRequestHandler<GetAllByTierAndUserRequest, GetAllByTierAndUserResponse>
{
    private readonly IUserAnswerRepository userAnswerRepository = userAnswerRepository;
    private readonly IMapper mapper = mapper;

    public async Task<GetAllByTierAndUserResponse> Handle(GetAllByTierAndUserRequest request, CancellationToken cancellationToken) 
    {
        if (request.ItemId == Guid.Empty)
            throw new Exception("O item não foi encontrado");

        var answerList = userAnswerRepository.GetAllByItemId(request.ItemId);
        
        return mapper.Map<GetAllByTierAndUserResponse>(answerList);
    }
}
