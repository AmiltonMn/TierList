using AutoMapper;
using MediatR;
using TagModel = TierListAPI.Entities.Models.Tag;
using TierListAPI.Persistence.Repository;
using TierListAPI.Common;
using TierListAPI.Common.ExceptionMessages;

namespace TierListAPI.Features.Tag.GetAll;

public class GetAllTagHandler
(
    ITagRepository tagRepository,
    IMapper mapper
) : IRequestHandler<GetAllTagRequest, GetAllTagResponse> 
{
    public async Task<GetAllTagResponse> Handle(GetAllTagRequest request, CancellationToken cancellationToken)
    {
        var tags = await tagRepository.GetAll(cancellationToken) ?? throw new NotFoundException(ExceptionMessage.NotFound.Tag);

        return mapper.Map<GetAllTagResponse>(tags);
    }
}
