using AutoMapper;
using MediatR;
using TagModel = TierListAPI.Entities.Models.Tag;
using TierListAPI.Persistence.Repository;

namespace TierListAPI.Features.Tag.GetAll;

public class GetAllTagHandler
(
    ITagRepository tagRepository,
    IMapper mapper
) : IRequestHandler<GetAllTagRequest, GetAllTagResponse> 
{
    public async Task<GetAllTagResponse> Handle(GetAllTagRequest request, CancellationToken cancellationToken)
    {
        var tags = await tagRepository.GetAll(cancellationToken) ?? throw new Exception("Não foi possível buscar as tags.");

        return mapper.Map<GetAllTagResponse>(tags);
    }
}
