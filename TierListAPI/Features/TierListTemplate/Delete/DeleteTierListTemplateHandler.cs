using AutoMapper;
using MediatR;
using TierListAPI.Persistence.Repository;

namespace TierListAPI.Features.TierListTemplate.Delete;

public class DeleteTierListTemplateHandler(
    ITierListTemplateRepository tierListTemplateRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IRequestHandler<DeleteTierListTemplateRequest, DeleteTierListTemplateResponse> {
    private readonly ITierListTemplateRepository tierListTemplateRepository = tierListTemplateRepository;
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IMapper mapper = mapper;

    public async Task<DeleteTierListTemplateResponse> Handle(DeleteTierListTemplateRequest request, CancellationToken cancellationToken)
    {
        if (request.TemplateId == Guid.Empty) 
            throw new Exception("ID nulo, por favor forneça um ID válido.");

        Entities.Models.TierListTemplate? tierListTemplate = await tierListTemplateRepository.GetById(request.TemplateId, cancellationToken);

        if (tierListTemplate == null)
            throw new Exception("Tier List não encontrada");

        tierListTemplate.IsDeleted = true;
        tierListTemplate.DeletedAt = DateTime.UtcNow;

        tierListTemplateRepository.Update(tierListTemplate);

        await unitOfWork.Save(cancellationToken);

        return mapper.Map<DeleteTierListTemplateResponse>(tierListTemplate);
    }
}