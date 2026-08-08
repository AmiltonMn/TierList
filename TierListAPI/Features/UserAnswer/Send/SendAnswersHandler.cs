using AutoMapper;
using MediatR;
using TierListAPI.Common;
using TierListAPI.Common.ExceptionMessages;
using TierListAPI.Persistence.Repositories;
using TierListAPI.Persistence.Repository;

namespace TierListAPI.Features.UserAnswer.Send;

public class SendAnswersHandler
(
    IUserAnswerRepository userAnswerRepository,
    IItemRepository itemRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IRequestHandler<SendAnswersRequest, SendAnswersResponse>
{
    public async Task<SendAnswersResponse> Handle(SendAnswersRequest request, CancellationToken cancellationToken) 
    {
        var usersAnswers = userAnswerRepository.
            GetAllByTemplateId(request.TemplateId)
            .GroupBy(ua => ua.ItemId)
            .Select(g => new 
            { 
                ItemId = g.Key, 
                AverageScore = g.Average(ua => ua.Score) 
            });

        foreach (var answer in usersAnswers)
        {
            var item = await itemRepository.GetById(answer.ItemId, cancellationToken) ?? throw new NotFoundException(ExceptionMessage.NotFound.TierListTemplate);

            item.Score = answer.AverageScore;

            itemRepository.Update(item);
        }

        await unitOfWork.Save(cancellationToken);

        return mapper.Map<SendAnswersResponse>(usersAnswers);
    }
}
