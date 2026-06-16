using AutoMapper;
using MediatR;
using TierListAPI.Common;
using TierListAPI.Common.ExceptionMessages;
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
        var userAnswer = await userAnswerRepository.GetById(request.Answer.Id, cancellationToken) ?? throw new NotFoundException(ExceptionMessage.NotFound.Default);

        if (userAnswer.TierId != Guid.Empty && userAnswer.TierId != null)
        {
            if (userAnswerRepository.GetAllByUserIdAndTierIdAndTemplateId(request.UserId, request.TemplateId, userAnswer.TierId).Count > 0)
                throw new DuplicityException(ExceptionMessage.NotFound.UserAnswer);
        }

        userAnswer = request.Answer;

        userAnswerRepository.Update(userAnswer);

        await unitOfWork.Save(cancellationToken);

        return mapper.Map<UpdateAnswerResponse>(userAnswer);
    }
}
