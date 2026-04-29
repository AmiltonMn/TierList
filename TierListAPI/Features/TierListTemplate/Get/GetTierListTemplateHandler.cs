using AutoMapper;
using MediatR;
using TierListAPI.Entities.Models;
using TierListAPI.Persistence.Repository;

namespace TierListAPI.Features.TierListTemplate.Get;
public class GetByQueryTierListTemplateHandler(
    ITierListTemplateRepository tierListTemplateRepository,
    IMapper mapper
) : IRequestHandler<GetByQueryTierListTemplateRequest, GetByQueryTierListTemplateResponse>
{
    private readonly ITierListTemplateRepository tierListTemplateRepository = tierListTemplateRepository;
    private readonly IMapper mapper = mapper;

    public async Task<GetByQueryTierListTemplateResponse> Handle(GetByQueryTierListTemplateRequest request, CancellationToken cancellationToken)
    {
        if (request.TemplateId == Guid.Empty)
            throw new Exception("ID nulo, por favor insira um ID válido.");

        var tierListTemplate = await tierListTemplateRepository.GetById(request.TemplateId, cancellationToken);

        return mapper.Map<GetByQueryTierListTemplateResponse>(tierListTemplate);
    }
}