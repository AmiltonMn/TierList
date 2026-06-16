using AutoMapper;
using MediatR;
using TierListAPI.Common;
using TierListAPI.Common.ExceptionMessages;
using TierListAPI.Persistence.Repository;
using TierListAPI.Persistence.Repository.Submission;

namespace TierListAPI.Features.Tier.Delete;

public class DeleteTierHandler (
    ITierRepository tierRepository,
    IUserAnswerRepository userAnswerRepository,
    ITierListTemplateRepository tierListTemplateRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IRequestHandler<DeleteTierRequest, DeleteTierResponse> {
    public async Task<DeleteTierResponse> Handle(DeleteTierRequest request, CancellationToken cancellationToken)
    {
        var tier = await tierRepository.GetById(request.Id, cancellationToken) ?? throw new NotFoundException(ExceptionMessage.NotFound.Tier);

        if(tierListTemplateRepository.GetById(tier.TierListTemplateId, cancellationToken).Result?.Tiers.Count <= 3) 
            throw new BadRequestException("Não foi possível apagar esse tier. São necessários ao menos 3 tiers em uma tier list.");

        var answerList = userAnswerRepository.GetAllByTierId(request.Id);

        if (answerList != null)
            throw new BadRequestException($"Esse tier não pode ser deletado, pois existem {answerList.Count} respostas nele.");
        
        tier.DeletedAt = DateTime.UtcNow;
        tier.IsDeleted = true;

        tierRepository.Update(tier);

        await unitOfWork.Save(cancellationToken);

        return mapper.Map<DeleteTierResponse>(tier); 
    }
}
