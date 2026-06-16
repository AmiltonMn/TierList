using AutoMapper;
using MediatR;
using TierListAPI.Common;
using TierListAPI.Common.ExceptionMessages;
using TierListAPI.Persistence.Repository;

namespace TierListAPI.Features.Tag.Update;

public class UpdateTagHandler 
(
    ITagRepository tagRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IRequestHandler<UpdateTagRequest, UpdateTagResponse>
{

    public async Task<UpdateTagResponse> Handle(UpdateTagRequest request, CancellationToken cancellationToken) 
    {
        var tag = tagRepository.GetById(request.TagId, cancellationToken).Result ?? throw new NotFoundException(ExceptionMessage.NotFound.Tag);

        if (request.Label.IsWhiteSpace() || request.Label == "" || request.Color.IsWhiteSpace() || request.Color == "")
            throw new BadRequestException("O valor de nome e de cor não podem estar vazios.");

        tag.Color = request.Color;
        tag.Label = request.Label;

        tagRepository.Update(tag);

        await unitOfWork.Save(cancellationToken);

        return mapper.Map<UpdateTagResponse>(tag);
    }
}
