using AutoMapper;
using MediatR;
using TierListAPI.Persistence.Repositories;
using TierListAPI.Persistence.Repository;
using UserAnswerModel = TierListAPI.Entities.Models.UserAnswer;

namespace TierListAPI.Features.UserAnswer.Create;

public class CreateUserAnswerHandler (
    IUserAnswerRepository userAnswerRepository,
    ITierListTemplateRepository tierListTemplateRepository,
    ITierRepository tierRepository,
    IUserRepository userRepository,
    ItemRepository itemRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IRequestHandler<CreateUserAnswerRequest, CreateUserAnswerResponse> {
    private readonly IUserAnswerRepository userAnswerRepository = userAnswerRepository;
    private readonly ITierListTemplateRepository tierListTemplateRepository = tierListTemplateRepository;
    private readonly ITierRepository tierRepository = tierRepository;
    private readonly IUserRepository userRepository = userRepository;
    private readonly IItemRepository itemRepository = itemRepository;
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IMapper mapper = mapper;

    public async Task<CreateUserAnswerResponse> Handle(CreateUserAnswerRequest request, CancellationToken cancellationToken) 
    {
        var tierList = await tierListTemplateRepository.GetById(request.TierListId, cancellationToken) ?? throw new Exception("O tier list não foi encontrado.");

        var tier = await tierRepository.GetById(request.TierId, cancellationToken) ?? throw new Exception("O tier não foi encontrado.");
        var user = await userRepository.GetById(request.UserId, cancellationToken) ?? throw new Exception("Usuário não encontrado.");
        var item = await itemRepository.GetById(request.ItemId, cancellationToken) ?? throw new Exception("Item não encontrado.");

        var answer = new UserAnswerModel
        {
            UserId = request.UserId,
            User = user,
            TierId = request.TierId,
            Tier = tier,
            ItemId = request.ItemId,
            Item = item,
            TierListId = request.TierListId,
            TierList = tierList,
            Score = 0
        };

        var userAnswersOnTier = userAnswerRepository.GetAllByUserIdAndTierIdAndTemplateId(request.UserId, request.TierListId, request.TierId).Count;

        answer.Score = tier.Points + 1 - (1 / userAnswersOnTier * (request.Order + 1));

        userAnswerRepository.Add(answer);
        await unitOfWork.Save(cancellationToken);

        return mapper.Map<CreateUserAnswerResponse>(answer);
    }
}
