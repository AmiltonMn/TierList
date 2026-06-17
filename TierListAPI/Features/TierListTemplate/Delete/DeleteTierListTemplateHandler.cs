using AutoMapper;
using MediatR;
using TierListAPI.Common;
using TierListAPI.Common.ExceptionMessages;
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
            throw new NotFoundException(ExceptionMessage.NotFound.TierListTemplate);

        Entities.Models.TierListTemplate? tierListTemplate = await tierListTemplateRepository.GetById(request.TemplateId, cancellationToken) ?? throw new NotFoundException(ExceptionMessage.NotFound.TierListTemplate);

        if (tierListTemplate.OwnerId != request.UserId)
            throw new UnauthorizedException(ExceptionMessage.Unauthorized.Default);

        tierListTemplate.IsDeleted = true;
        tierListTemplate.DeletedAt = DateTime.UtcNow;

        tierListTemplateRepository.Update(tierListTemplate);

        await unitOfWork.Save(cancellationToken);

        return mapper.Map<DeleteTierListTemplateResponse>(tierListTemplate);
    }
}