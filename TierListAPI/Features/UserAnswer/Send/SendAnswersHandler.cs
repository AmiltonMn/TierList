using AutoMapper;
using MediatR;
using TierListAPI.Persistence.Repositories;
using TierListAPI.Persistence.Repository;

namespace TierListAPI.Features.UserAnswer.Send;

public class SendAnswersHandler
(
    IUserAnswerRepository userAnswerRepository,
    ItemRepository itemRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IRequestHandler<SendAnswersRequest, SendAnswersResponse>
{
    private readonly IUserAnswerRepository userAnswerRepository = userAnswerRepository;
    private readonly IItemRepository itemRepository = itemRepository;
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IMapper mapper = mapper;

    public async Task<SendAnswersResponse> Handle(SendAnswersRequest request, CancellationToken cancellationToken) 
    {
        var userAnswers = userAnswerRepository.
            GetAllByTemplateId(request.TemplateId)
            .GroupBy(ua => ua.ItemId)
            .Select(g => new 
            { 
                ItemId = g.Key, 
                AverageScore = g.Average(ua => ua.Score) 
            });

        foreach (var answer in userAnswers)
        {
            var item = await itemRepository.GetById(answer.ItemId, cancellationToken) ?? throw new Exception("O item não foi encontrado.");

            item.Score = answer.AverageScore;

            itemRepository.Update(item);
        }
    }
}
