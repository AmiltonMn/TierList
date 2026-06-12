using AutoMapper;
using MediatR;
using TierListAPI.Persistence.Repository;

namespace TierListAPI.Features.Item.GetAllByTemplate;

public class GetAllByTemplateHandler (
    IItemRepository itemRepository,
    IMapper mapper
) : IRequestHandler<GetAllByTemplateRequest, GetAllByTemplateResponse>
{
    public async Task<GetAllByTemplateResponse> Handle(GetAllByTemplateRequest request, CancellationToken cancellationToken)
    {
        var items = itemRepository.GetByTierListTemplateId(request.TemplateId) ?? throw new Exception("Nenhum item foi encontrado na tierlist.");
    
        return mapper.Map<GetAllByTemplateResponse>(items);
    }
}
