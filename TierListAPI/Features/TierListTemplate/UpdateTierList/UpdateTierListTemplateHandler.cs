using AutoMapper;
using MediatR;
using TierListAPI.Common;
using TierListAPI.Common.ExceptionMessages;
using TierListAPI.Persistence.Repository;

namespace TierListAPI.Features.TierListTemplate.Update;

public class UpdateTierListTemplateHandler(
    ITierListTemplateRepository tierListTemplateRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IRequestHandler<UpdateTierListTemplateRequest, UpdateTierListTemplateResponse> {
    private readonly ITierListTemplateRepository tierListTemplateRepository = tierListTemplateRepository;
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IMapper mapper = mapper;

    public async Task<UpdateTierListTemplateResponse> Handle(UpdateTierListTemplateRequest request, CancellationToken cancellationToken)
    {
        if (request.TemplateId == Guid.Empty)
            throw new BadRequestException("ID nulo, insira um ID válido.");

        if (request.Name.IsWhiteSpace() || request.Name == "")
            throw new BadRequestException("Nome vazio, insira um nome válido.");

        if (request.Description.IsWhiteSpace() || request.Description == "")
            throw new BadRequestException("Descrição vazia, insira uma descrição válida.");

        if (request.Tags.Count == 0)
            throw new BadRequestException("Selecione ao menos uma tag");

        var tierListTemplate = await tierListTemplateRepository.GetById(request.TemplateId, cancellationToken) ?? throw new NotFoundException(ExceptionMessage.NotFound.TierListTemplate);

        tierListTemplate.Name = request.Name;
        tierListTemplate.Description = request.Description;
        tierListTemplate.IsPrivate = request.IsPrivate;
        tierListTemplate.Tags = request.Tags;

        tierListTemplateRepository.Update(tierListTemplate);

        await unitOfWork.Save(cancellationToken);

        return mapper.Map<UpdateTierListTemplateResponse>(tierListTemplate);
    }
}