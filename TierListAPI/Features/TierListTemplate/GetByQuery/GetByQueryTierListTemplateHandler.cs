using AutoMapper;
using MediatR;
using TierListAPI.Entities.Models;
using TierListAPI.Persistence.Repository;

namespace TierListAPI.Features.TierListTemplate.GetByQuery;
public class GetByQueryTierListTemplateHandler(
    ITierListTemplateRepository tierListTemplateRepository,
    IMapper mapper
) : IRequestHandler<GetByQueryTierListTemplateRequest, GetByQueryTierListTemplateResponse>
{
    private readonly ITierListTemplateRepository tierListTemplateRepository = tierListTemplateRepository;
    private readonly IMapper mapper = mapper;

    public async Task<GetByQueryTierListTemplateResponse> Handle(GetByQueryTierListTemplateRequest request, CancellationToken cancellationToken)
    {
        var tierListTemplates = tierListTemplateRepository.GetPaginatedTiers(request.PageNumber, request.PageSize, request.SearchByName, request.TagId, request.UserId, request.LoggedUser);

        return mapper.Map<GetByQueryTierListTemplateResponse>(tierListTemplates);
    }
}