using AutoMapper;
using MediatR;
using TierListAPI.Persistence.Repository;

namespace TierListAPI.Features.UserAnswer.Update;

public class UpdateAnswerHandler 
(
    IUserAnswerRepository userAnswerRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IRequestHandler<UpdateAnswerRequest, UpdateAnswerResponse> {

    public async Task<UpdateAnswerResponse> Handle(UpdateAnswerRequest request, CancellationToken cancellationToken) 
    {
        var userAnswer = await userAnswerRepository.GetById(request.Answer.Id, cancellationToken) ?? throw new Exception("Resposta não encontrada.");

        userAnswer = request.Answer;

        userAnswerRepository.Update(userAnswer);

        await unitOfWork.Save(cancellationToken);

        return mapper.Map<UpdateAnswerResponse>(userAnswer);
    }
}
