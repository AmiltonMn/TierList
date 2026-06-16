using AutoMapper;
using MediatR;
using TagModel = TierListAPI.Entities.Models.Tag;
using TierListAPI.Persistence.Repository;
using System.Drawing;
using TierListAPI.Common;

namespace TierListAPI.Features.Tag.Create;

public class CreateTagHandler
(
    ITagRepository tagRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IRequestHandler<CreateTagRequest, CreateTagResponse> {

    public async Task<CreateTagResponse> Handle(CreateTagRequest request, CancellationToken cancellationToken) 
    {
        if (request.Label.IsWhiteSpace() || request.Color.IsWhiteSpace())
            throw new BadRequestException("Para criar uma tag, é necessário uma cor e um nome.");

        TagModel tag = new()
        {
            Color = request.Color,
            Label = request.Label
        };

        tagRepository.Add(tag);

        await unitOfWork.Save(cancellationToken);

        return mapper.Map<CreateTagResponse>(tag);
    }
}
