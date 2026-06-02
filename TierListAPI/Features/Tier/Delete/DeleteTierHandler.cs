using AutoMapper;
using MediatR;
using TierListAPI.Persistence.Repository;

namespace TierListAPI.Features.Tier.Delete;

public class DeleteTierHandler (
    ITierRepository tierRepository,
    IUserAnswerRepository userAnswerRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IRequestHandler<DeleteTierRequest, DeleteTierResponse> {
    private readonly ITierRepository tierRepository = tierRepository;
    private readonly IUserAnswerRepository userAnswerRepository = userAnswerRepository;
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IMapper mapper = mapper;

    public async Task<DeleteTierResponse> Handle(DeleteTierRequest request, CancellationToken cancellationToken)
    {
        var tier = await tierRepository.GetById(request.Id, cancellationToken) ?? throw new Exception("O Tier não foi encontrado.");

        var answerList = userAnswerRepository.GetAllByTierId(request.Id);

        if (answerList != null)
            throw new Exception($"Esse tier não pode ser deletado, pois existem {answerList.Count} respostas nele.");
        
        tier.DeletedAt = DateTime.UtcNow;
        tier.IsDeleted = true;

        tierRepository.Update(tier);

        await unitOfWork.Save(cancellationToken);

        return mapper.Map<DeleteTierResponse>(tier); 
    }
}
